#include <DHT.h>
#include <DHT_U.h>

#define DHTPIN 2 //ESP8266 Pin D4 / ESP32 Pin G2
#define DHTTYPE DHT11

DHT dht(DHTPIN, DHTTYPE);

void setup() {
  Serial.begin(9600);

  Serial.println("Welcome to DHT Test!");
  
  dht.begin();
}

void loop() {
  delay(2000);

  //With real DHT 
  //float humidity = dht.readHumidity();
  //float temperature = dht.readTemperature();

  //Without real DHT
  float humidity = readHumidity();
  float temperature = readTemperature();

  if(isnan(humidity) || isnan(temperature)) {
    return;
  }

  Serial.print(F("Humidity: "));
  Serial.print(humidity);
  Serial.print(F("%  Temperature: "));
  Serial.print(temperature);
  Serial.print(F("°C "));
  Serial.println("");
 
}

float readHumidity()
{
    float value = 100;
  
    return random(5000,  6500) / value;
}

float readTemperature()
{
    float value = 100;
    return random(1900,  2300) / value;
}
