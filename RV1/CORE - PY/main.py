"""
'||''|.  '||''|.    ..|''||      '||' '||''''|    ..|'''.| |''||''|
 ||   ||  ||   ||  .|'    ||      ||   ||  .    .|'     '     ||
 ||...|'  ||''|'   ||      ||     ||   ||''|    ||            ||
 ||       ||   |.  '|.     ||     ||   ||       '|.      .    ||
.||.     .||.  '|'  ''|...|'  || .|'  .||.....|  ''|....'    .||.
                               '''                                         
                                                                           
'||'  '||' '||' '|' '||''|.  '||''''|  '||''|.   '||'  ..|''||   '|.   '|'
 ||    ||    || |    ||   ||  ||  .     ||   ||   ||  .|'    ||   |'|   |
 ||''''||     ||     ||...|'  ||''|     ||''|'    ||  ||      ||  | '|. |  
 ||    ||     ||     ||       ||        ||   |.   ||  '|.     ||  |   |||  
.||.  .||.   .||.   .||.     .||.....| .||.  '|' .||.  ''|...|'  .|.   '|  

Now with fancy green hacker text!
"""

# Just your run-of-the-mill imports.
import json

import trilobot
import board
import adafruit_bh1750
import busio
import adafruit_sgp40
from flask import Flask, request

app = Flask(__name__)  # Flask initialisation

tbot = Trilobot() # Car initialisation.

# Sensor Initialisation.
i2c = board.I2C()
Busi2c = busio.I2C(board.SCL, board.SDA)
BH1750 = adafruit_bh1750.BH1750(i2c)
SGP40 = adafruit_sgp40.SGP40(i2c)

# This gets a Lux reading
@app.route('/Lux', methods=['GET'])
def Lux():
    return BH1750.lux

# This gets a Raw Gas reading
@app.route('/RawGas', methods=['GET'])
def RawGas():
    return SGP40.raw

# This gets a Temperature reading
@app.route('/Temperature', methods=['GET'])
def Temprature():
    return SGP40.temperature

# This gets a humidity reading
@app.route('/humidity', methods=['GET'])
def Temprature():
    return SGP40.relative_humidity

@app.route('/Move', methods=['POST'])
def update_record():
    ID = json.loads(request.data)

    if ID.contains("0"):
        tbot.set_left_speed(-1)
        tbot.set_right_speed(-1)
    elif ID.contains("1"):
        tbot.set_left_speed(1)
        tbot.set_right_speed(1)
    elif ID.contains("2"):
        tbot.set_left_speed(0.75)
        tbot.set_right_speed(1)
    elif ID.contains("3"):
        tbot.set_left_speed(1)
        tbot.set_right_speed(0.75)
    else:
        tbot.set_left_speed(0)
        tbot.set_right_speed(0)

app.run(debug=True)