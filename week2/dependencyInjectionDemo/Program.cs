IEngine sport = new Engine("Sport", 350, 6); // Created a future dependency

Car myCar = new Car(sport); // Passing the dependency

myCar.printingEngineDetails();
