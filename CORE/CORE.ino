/*
    ____  ____  ____      ____________________    
   / __ \/ __ \/ __ \    / / ____/ ____/_  __/    
  / /_/ / /_/ / / / /_  / / __/ / /     / /       
 / ____/ _, _/ /_/ / /_/ / /___/ /___  / /        
/_/ __/_/_|_|\____/\____/_____/\____/_/_/_  _   __
   / / / /\ \/ / __ \/ ____/ __ \/  _/ __ \/ | / /
  / /_/ /  \  / /_/ / __/ / /_/ // // / / /  |/ / 
 / __  /   / / ____/ /___/ _, _// // /_/ / /|  /  
/_/_/_/___/_/_/___/_____/_/ |_/___/\____/_/ |_/   
  / ____/ __ \/ __ \/ ____/  _   _|__ \           
 / /   / / / / /_/ / __/    | | / /_/ /           
/ /___/ /_/ / _, _/ /___    | |/ / __/            
\____/\____/_/ |_/_____/    |___/____/           
                                                  
Now with 105% cooler text than V1!
*/

//BMP 3xx Imports
#include <Adafruit_BMP3XX.h>
#include <bmp3.h>
#include <bmp3_defs.h>

//Wifi Imports for webserver
#include <WiFi.h>
#include <WiFiClient.h>
#include <WebServer.h>
#include <ESPmDNS.h>
#include "Adafruit_APDS9960.h" //APDS Imports.

Adafruit_APDS9960 apds; //APDS Sensor Manager
Adafruit_BMP3XX bmp; //BMP390 Sensor Manager
WebServer server(80); //Webserver manager

const int led = 13;

void setup(void) {
  Serial.begin(115200); //Starts Serial Connection for Debugging

  //Disables LED as a superstion as enabling caused power draw issues.
  Serial.println("NSR Software - Project HYPERION CORE V2.3\nSerial initalised.\nDisabling LED.");
  pinMode(led, OUTPUT);
  digitalWrite(led, 0);
  Serial.println("LED Disabled.\nCreating Wifi Access Point");

  //Creates an open Wifi network called HYPERION, doesn't have a password. (This is for the quest to connect to and send/recieve data)
  WiFi.mode(WIFI_AP,WIFI_PROTOCOL_LR);
  WiFi.softAP("HYPERION", NULL);
  Serial.println("Wifi Access Point Created.\nConfiguring Sensor");

  SensorConfig(); //This initalises the above sensors.

  //The following defines various endpoints
  server.on("/Temp", []() { //Temperature Endpoint, returns as Celcius
    if (bmp.performReading()) { server.send(200, "text/plain", String(bmp.temperature)); }
    else {server.send(200, "text/plain", "Sensor Error");}});

  server.on("/Pressure", []() { //Pressure Endpoint, returns as HPa (according to Sam)
    if (bmp.performReading()) { server.send(200, "text/plain", String(bmp.pressure / 100.0)); }
    else {server.send(200, "text/plain", "Sensor Error");}});

  server.on("/Altitude", []() { //Altitude Endpoint, needs local sea level (1017 is the reading for sheffield)
    if (bmp.performReading()) { server.send(200, "text/plain",String(bmp.readAltitude(1017.00))); }
    else {server.send(200, "text/plain", "Sensor Error");}});

  server.on("/Color", []() { //Color Endpoint, returns value of the color the APDS is looking at.
    uint16_t r, g, b, c;
    while(!apds.colorDataReady()) { delay(5); }
    apds.getColorData(&r, &g, &b, &c);
    String Reading = "Red:" + String(r) + " Green:" + String(g) + " Blue:" + String(b) + " Clear:" + String(c);
    if (bmp.performReading()) { server.send(200, "text/plain",Reading); }
    else {server.send(200, "text/plain", "Sensor Error");}});


  //These are move endpoints, they only print serial when hit so they are kind of stubs but the Trilobot can read them.
  server.on("/MoveFOR", []() {
      server.send(200, "text/plain", "Recieved.");
      Serial.println("FOR"); });

  server.on("/MoveFLT", []() {
      server.send(200, "text/plain", "Recieved.");
      Serial.println("FLT"); });
    
  server.on("/MoveFRT", []() {
      server.send(200, "text/plain", "Recieved.");
      Serial.println("FRT"); });    
    
  server.on("/MoveRRT", []() {
      server.send(200, "text/plain", "Recieved.");
      Serial.println("RRT"); });
      
  server.on("/MoveRLT", []() {
      server.send(200, "text/plain", "Recieved.");
      Serial.println("RLT"); });
      
  server.on("/MoveREV", []() {
      server.send(200, "text/plain", "Recieved.");
      Serial.println("REV"); });

  server.on("/DontMove", []() {
      server.send(200, "text/plain", "Recieved.");
      Serial.println("NUL");  });
    
  //Starts web server now that endpoints are declared.
  server.begin();
  Serial.println("HTTP server started");
}


//Does all sensor init stuff.
void SensorConfig()
{
    //BMP390 Initalisation
    Serial.println("Configuring BMP3XX Sensor");
    if (bmp.begin_I2C()) //this will start up the BMP390 and everything needed, if this goes well it return true, if not it will return false.
    {
      //Ideal settings for this use case (as per PLACEHOLDER), then print sample reading of temp, pres and alt.
      bmp.setTemperatureOversampling(BMP3_OVERSAMPLING_8X); 
      bmp.setPressureOversampling(BMP3_OVERSAMPLING_4X);
      bmp.setIIRFilterCoeff(BMP3_IIR_FILTER_COEFF_3);
      bmp.setOutputDataRate(BMP3_ODR_50_HZ);
      Serial.println("BMP Configuration Complete, taking sample reading.");
      Serial.println("BMPXX returned Altitude: " + String(bmp.readAltitude(1017.00)) + " Pressure: " + String(bmp.pressure / 100.0) + " Temprature: " + String(bmp.temperature));
    }
    else{ Serial.println("BMPXX Sensor Initalisation FAILED."); }
  
    if(apds.begin()) { apds.enableColor(true); }
    else { Serial.println("APDS init failed."); }
}

//This cool function runs forever.
void loop(void) {
  server.handleClient(); //Handles webserver stuff.
  delay(2);
}
