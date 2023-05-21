unsigned long time ;
long gram ;
void setup() {
  Serial.begin(9600);
}

void loop() {
 gram = 150;
 Serial.println(gram);
}
