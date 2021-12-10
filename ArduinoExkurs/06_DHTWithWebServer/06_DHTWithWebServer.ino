#if defined(ESP8266)
#include <ESP8266WiFi.h>
#include <ESP8266WebServer.h>

#elif defined(ESP32)
#include <WiFi.h>
#else
#endif
#include <DHT.h>
#include <DHT_U.h>

#define DHTPIN 2 //ESP8266 Pin D4 / ESP32 Pin G2
#define DHTTYPE DHT11

const char* ssid = "REPLACE_WITH_YOUR_SSID";
const char* password = "REPLACE_WITH_YOUR_PASSWORD";

DHT dht(DHTPIN, DHTTYPE);
ESP8266WebServer server(80);
//WebServer server(80);

void handleRoot();
void handleTemp();

float temperature = 0;
float humidity = 0;

void setup() {
  Serial.begin(9600);
  delay(10);

  Serial.print("Verbinde mit: ");
  Serial.println(ssid);

  WiFi.begin(ssid, password);

  //Warten bis WLAN verbunden ist
  while (WiFi.status() != WL_CONNECTED) {
    delay(500);
    Serial.print(".");
  }

  Serial.println("");
  Serial.println("WiFi verbunden");


  Serial.println("Server started");

  Serial.print("Go to ip:");
  
  Serial.print("http://");
  Serial.print(WiFi.localIP());
  Serial.println("/");

  Serial.println("Welcome to the simple DHT WebServer!");

  dht.begin();

  server.on("/", handleRoot);
  server.on("/temp", handleTemp);

  
  //Starten vom WebServer
  server.begin();
}

void handleRoot(){
  server.send(200, "text/html", "<html><body><h1>hello world</h1></body></html>");
}

void handleTemp(){
  server.send(200, "text/plain", String(temperature).c_str());
}

void loop() {
  server.handleClient();
  
  delay(1000);

  //With real DHT
  //float humidity = dht.readHumidity();
  //float temperature = dht.readTemperature();

  //Without real DHT
  humidity = readHumidity();
  temperature = readTemperature();

  if (isnan(humidity) || isnan(temperature)) {
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
