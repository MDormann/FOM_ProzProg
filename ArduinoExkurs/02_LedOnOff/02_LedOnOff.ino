//Beispiel für eine Konstante (Man kann hiermit Pins auch Namen vergeben, was eine bessere Lesbarkeit später ermöglicht (Bad: pinMode(1,1) / Better: pinMode(PIN1, OUTPUT))
const int PIN1 = 1;
const int PIN5 = 5;

//Diese Variablen gelten global bis zum Neustart des Controllers, da im RAM
int val = 0;
int LEDMode = 0;

void setup() {
  // initialize digital pin LED_BUILTIN as an output.
  pinMode(LED_BUILTIN, OUTPUT);
  pinMode(PIN5, INPUT);
}

void loop() {
  val = digitalRead(PIN5); //Liest den Wert von GPIO Pin 1 aus (0,1)

  if(val == 1)
  {
    digitalWrite(PIN1, LOW);
  } else {
    digitalWrite(PIN1, HIGH); 
  }
}
