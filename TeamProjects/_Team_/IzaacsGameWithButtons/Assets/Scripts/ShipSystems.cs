using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


namespace Assets.Scripts
{

    class AerodynamicModel
    {
        GameObject shape;

        public AerodynamicModel(GameObject shape) { this.shape = shape; }

        public GameObject getShape() { return shape; }

    }

    class FuelType 
    {
        float mass;
        float density;
        float energy;

        public FuelType() { }

        public FuelType(float mass, float density, float energy) {
            this.energy = energy;
            this.density = density;
            this.mass = mass;
        }

        public float getMass() { return mass; }
        public float getDensity() { return density; }
        public float getEnergy() { return energy; }

    }

    class Structure 
    {
        //instance data
        int structureType;
        static int numFuelTanks;
        FuelTank[] tanks = new FuelTank[numFuelTanks];
        Pipe fuelPipes = new Pipe(5, 1000);
        Pipe coolantPipe = new Pipe(1, 5);
        Wires wires = new Wires(10, 50, 5000);
        Hull hull = new Hull(100000, 1000, 0);

        //constructors
        public Structure(int structureType) {
            this.structureType = structureType; 
            createStructrue();
        }

        //accessors
        public int getStructureType() { return structureType; }

        //mutators
        public void setFuelType(int fuelType)
        {
            for (int i = 0; i < tanks.Length; i++)
            {
                tanks[i].setFuelType(fuelType);
            }
        }
        public void setFuelVolume(float volume)
        {
            for (int i = 0; i < tanks.Length; i++)
            {
                tanks[i].setVolume(volume);
            }
        }
        private void createStructrue()
        {
            if (structureType == 0)
            {
                numFuelTanks = 1;
                for (int i = 0; i < tanks.Length; i++)
                {
                    tanks[i].setCapacity(1000);
                    tanks[i].setFuelType(0);
                    tanks[i].setVolume(0);
                    tanks[i].calcTotalMass();
                }

                hull.setAeroModel(0);
                hull.setMass(100000);
                hull.setStrength(1000);

                fuelPipes.setDiameter(5);
                fuelPipes.setMass(1000);
                coolantPipe.setDiameter(1);
                coolantPipe.setMass(5);

                wires.setMass(10);
                wires.setHeatOutput(10);
                wires.setMaxInput(1000);

            }

            if (structureType == 1)
            {
                numFuelTanks = 3;
                for (int i = 0; i < tanks.Length; i++)
                {
                    tanks[i].setCapacity(2000);
                    tanks[i].setFuelType(1);
                    tanks[i].setVolume(0);
                    tanks[i].calcTotalMass();
                }

                hull.setAeroModel(1);
                hull.setMass(200000);
                hull.setStrength(5000);

                fuelPipes.setDiameter(10);
                fuelPipes.setMass(2000);
                coolantPipe.setDiameter(2);
                coolantPipe.setMass(10);

                wires.setMass(11);
                wires.setHeatOutput(10);
                wires.setMaxInput(5000);

            }

            if (structureType == 2)
            {
                numFuelTanks = 5;
                for (int i = 0; i < tanks.Length; i++)
                {
                    tanks[i].setCapacity(5000);
                    tanks[i].setFuelType(2);
                    tanks[i].setVolume(0);
                    tanks[i].calcTotalMass();
                }

                hull.setAeroModel(2);
                hull.setMass(250000);
                hull.setStrength(10000);

                fuelPipes.setDiameter(15);
                fuelPipes.setMass(2500);
                coolantPipe.setDiameter(3);
                coolantPipe.setMass(15);

                wires.setMass(10);
                wires.setHeatOutput(15);
                wires.setMaxInput(10000);

            }
        }

        class FuelTank {
            float capacity;
            float tankMass;

            int fuelType;
            static FuelType[] fuelTypeList = { new FuelType(1, 1, 5), new FuelType(1, 0.5f, 2.5f), new FuelType(1, 0.25f, 1.25f) };
            float fuelMass;
            float fuelVolume;

            //constructors
            public FuelTank() { }
            public FuelTank(float capacity) { 
                this.capacity = capacity;
                calcTankMass();
            }
            public FuelTank(float capacity, int fuelType) {
                this.capacity = capacity;
                this.fuelType = fuelType;
                fuelMass = fuelTypeList[fuelType].getMass();
                calcTankMass();
            }


            //mutators
            public void setCapacity(float input) { capacity = input; }
            public void setFuelType(int input)   { fuelType = input; }
            public void setVolume(float input)   { fuelVolume = Mathf.Clamp(input, 0, capacity); }
            public void calcTankMass() {
                tankMass = 1000 * (this.capacity / 4);
            }
            public void calcFuelMass() {
                fuelMass = fuelVolume * fuelTypeList[fuelType].getDensity();
            }
            public void calcTotalMass(){
                calcFuelMass();
                calcTankMass();
            }

            //accessors
            public float getCapacity()   { return capacity;   }
            public float getTankMass()   { return tankMass;   }
            public float getFuelMass()   { return fuelMass;   }
            public float getFuelVolume() { return fuelVolume; }
            public float getCurrentMass(){
                float mass = fuelMass * fuelVolume;
                mass += tankMass;
                return mass;
            }
            public float getMass() {
                calcFuelMass();
                calcTankMass();
                return fuelMass + tankMass;
            }
            
        }

        class Pipe 
        {
            float diameter;
            float mass;

            public Pipe(float diameter, float mass) 
            {
                this.mass = mass;
                this.diameter = diameter;
            }

            public float getMass()     { return mass; }
            public float getDiameter() { return diameter; }

            public void setMass(float mass)         { this.mass = mass; }
            public void setDiameter(float diameter) { this.diameter = diameter; }
        }

        class Wires 
        {
            float mass;
            float heatOutput;

            float input, maxInput;
            float output, maxOutput;

            //accessors
            public float getMaxInput()     { return maxInput;   }
            public float getCurrentInput() { return input;      }
            public float getMass()         { return mass;       }
            public float getHeatOutput()   { return heatOutput; }
            
            //mutators
            public void setMaxInput(float input)        { maxInput = input;   }
            public void setInput(float input)           { this.input = input; }
            public void setMaxOutput(float input)       { maxOutput = input;  }
            public void setOutput(float input)          { output = input;     }
            public void setMass(float mass)             { this.mass = mass; }
            public void setHeatOutput(float heatOutput) { this.heatOutput = heatOutput; }

            //constructors
            public Wires() { }
            public Wires(float mass, float heatOutput) { this.mass = mass; this.heatOutput = heatOutput; }
            public Wires(float mass, float heatOutput, float maxInput)
            {
                this.mass = mass;
                this.heatOutput = heatOutput;
                this.maxInput = maxInput;
                maxOutput = maxInput;
            }

        }

        class Hull 
        {
            float strength;
            float mass;
            int aerodynamicModelIndex;
            static AerodynamicModel[] aeroModelList = { 
                new AerodynamicModel(new GameObject("aero_Model_0")), 
                new AerodynamicModel(new GameObject("aero_Model_1")) 
            };

            public Hull(float mass, float strength, int aerodynamicModel)
            {
                this.mass = mass;
                this.strength = strength;
                aerodynamicModel = Mathf.Clamp(aerodynamicModel, 0, aeroModelList.Length);
                this.aerodynamicModelIndex = aerodynamicModel;
            }

            public void setMass(int mass)         { this.mass = mass; }
            public void setStrength(int strength) { this.strength = strength; }
            public void setAeroModel(int model)   { this.aerodynamicModelIndex = model; }

            public float getMass()      { return mass; }
            public float getStrength()  { return strength; }
            public float getAeroModel() { return aerodynamicModelIndex; }
        }
    }

    class Engines 
    {
        float mass;
        float heatOutput;
        float effiency;
        float requiredPower;
        float thrust;

        public Engines(float mass, float heatOutput, float effiency, float requiredPower, float thrust) {
            this.mass = mass;
            this.heatOutput = heatOutput;
            this.effiency = effiency;
            this.requiredPower = requiredPower;
            this.thrust = thrust;
        }

        
    }

    class ShipSystems 
    {
        /*
         * spaceships have:
         *      engines, computer systems, generators, 
         *      cooling systems, navigation, comunication, structure
         *      
         * Sturcture
         *      hull
         *          strength
         *          shape
         *          mass
         *          *****arodymanics*****
         *      fuel tanks
         *          capacity
         *          tank mass
         *          fuel type
         *              fuel mass
         *              energy
         *      pipes
         *          diameter
         *          mass
         *      wires
         *          bandwidth
         *          regulators
         *              max input
         *          heat output
         *          mass
         * Engines
         *      input energy required
         *      thrust
         *      efficency
         *      heat output
         *      mass
         * Generators
         *      Min/Max Input/Output
         *      efficency
         *      heat output
         *      mass
         * Cooling systems
         *      efficency
         *      Max cooling
         *      energy required
         *      mass
         * Navigation
         *      positioning/targeting
         *      distance calc
         *      energy use calc
         *      time calc
         *      required energy
         *      efficency
         *      heat output
         *      calc speeds
         *          based on efficency, temp, and computer systems
         *      mass
         * Communication
         *      range
         *      required energy
         *      comunication speed
         *          based on distance from sending location
         *      com channel managment
         *          manually add com references by I.P.
         *          memory/hard drive space needed
         *      mass
         * Computer systems
         *      required energy
         *      computation speed
         *      heat output
         *      memory/hard drive space
         *      number of hard drives
         *      efficency
         *      mass
         * 
         */
    }
}