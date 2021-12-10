#if defined(ESP8266)
  #include <ESP8266WiFi.h>
  
#elif defined(ESP32)
  #include <WiFi.h>
  
#else
#endif

//Beispiel für eine Konstante (Man kann hiermit Pins auch Namen vergeben, was eine bessere Lesbarkeit später ermöglicht (Bad: pinMode(1,1) / Better: pinMode(PIN1, OUTPUT))
const int PIN1 = 1;

//Diese Variablen gelten global bis zum Neustart des Controllers, da im RAM
int val = 0;
int LEDMode = 0;

const char* ssid ="FRITZ!Box Gastzugang";
const char* password ="123456789";

WiFiServer server(80);

void setup() {
  // initialize digital pin LED_BUILTIN as an output.
  pinMode(1, OUTPUT);
  
  Serial.begin(9600);
  delay(10);
}

// the loop function runs over and over again forever
void loop() {
  //1. Beispiel eine <Hello World> Nachricht jede Sekunde
//  Serial.print("Hello World!\n");
//  delay(1000);

  int input = 0;

  //2. Beispiel Empfang von Daten von der seriellen Schnittstelle und Ausgabe der Daten über selbige. Hinweis: Serial Monitor der Arduino IDE
//  if(Serial.available()){
//    input = Serial.read();  
//  
//
//    Serial.print("Byte: \t");
//    Serial.print(input, BIN);
//    Serial.print("\t");
//    Serial.print(input, HEX);
//    Serial.print("\t");
//    Serial.print(input, DEC);
//    Serial.print("\n");
//  }

  //3. Beispiel 
//  if(Serial.available()){
//    String input = Serial.readString();
//    Serial.println(input);
//  }

  // 4. Beispiel Empfang und Befehlen (on/off) per serieller Schnittstelle und schalten der eingebauten LED (ESP32: Eingebaute LED kann leider nicht verwendet werden, weil sie am Pin von der seriellen Schnittstelle hängt)
  // Sample only working with ESP8266
  if(Serial.available()){
    String input = Serial.readString();

    if(input == "on") {
      LEDMode = 1;
    } else if (input == "off") {
      LEDMode = 0;
    }
  }

  digitalWrite(PIN1, LEDMode);

}
