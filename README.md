
![CellularAutomata](https://github.com/BasRuckebusch/CellularAutomata/assets/97399311/2539e25d-06ec-4260-8313-cfe8d6d992d7)

# Description
This project aims to provide a simple cave generation system in Unity.It uses cellular automata to generate random cave - like structures.


# Design/implementation
## Usage
The project itself consists of two scripts: CaveGenerator, which handles the cellular automata and CaveGeneration which functions as an interface and a way of displaying what generated.

CaveGeneration Script: 

- **Width and Height:** Set the dimensions of the cave you want to generate.
- **Floor and Wall Tiles:** Assign the floor and wall tiles to be used in the cave.
- **Generate:** Click this button in the Inspector to generate the initial cave layout.
- **Step:** Click this button to simulate one step of the cellular automata algorithm. You can use this to iteratively refine the cave structure.

CaveGenerator Script

- **Chance to Start Alive:** Control the initial probability of a cell being alive (1) or dead (0).
- **Birth Limit:** The minimum number of live neighbors required for a dead cell to become alive in the next step.
- **Death Limit:** The maximum number of live neighbors allowed for a live cell to stay alive in the next step.
- **Number of Steps:** Specify how many iterations of the cellular automata algorithm should be performed.

![image](https://github.com/BasRuckebusch/CellularAutomata/assets/97399311/bfc0028f-63e6-4dc7-96db-5b07501831c9)

## Generation

The real meat and potatoes of this project is the CaveGenerator script, it uses cellular automata to to easily create a procedurally generated 2d cave system.<br>

![CaveGen](https://github.com/BasRuckebusch/CellularAutomata/assets/97399311/bbab18a1-05cf-4c84-8284-dea4ba106b1c)

### How it Works:

### Generation of Map
First we initialise the map, each cell having a chance to be either alive or dead depening on the Chance to Start Alive. Then we will itterate trough it for a specified number of steps applying the simulation each time.

![image](https://github.com/BasRuckebusch/CellularAutomata/assets/97399311/b2ec42a9-53d0-4e66-93ee-542e72e0efd8)

### Simulation Step

The simulation steps themselves are quite simple:<br>

First we itterate over each and every cell and figure out how many of it's neighbours are alive, making sure not to include itself. 

Then we apply the two main rules:
- If the current cell in the previous step is true (i.e., alive), then the same cell in the new step is set to true if aliveNeighbours is greater than or equal to the Death Limit. This implies that if there are enough living neighbors around a cell, it survives in the next generation.<br>
- If the current cell in the previous step is false (i.e., dead), then the same cell in the new step is set to true if aliveNeighbours is greater than the Birth Limit. This implies that a new cell is born if it has enough living neighbors.<br>

# Result
The result is a wide array of procedural cave systems that's extremely adjustable!

![image](https://github.com/BasRuckebusch/CellularAutomata/assets/97399311/dda23015-4b44-4b79-98ab-9340d50f3cd8)
![results](https://github.com/BasRuckebusch/CellularAutomata/assets/97399311/ad820e7d-b53e-4a92-91bc-af618d0e23a0)


# Conclusion/Future work
This is a smaller project but nonetheless one I very much enjoyed making, it's robust, quite fast and something that's easily implemented in other projects.

Some expansions I would like to add are:
- A biome system so you can have multiple types of generation in the same map.
- A POI system where you'd be able to generate a structre in certain spots depending on some variables/
