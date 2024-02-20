# CSE528_FinalProject

Game Type: Tower Defense style
Game Name: 

Mechanics & Components:

  - # of towers (4); close-range, long-range, medium-range or another short-range
  - # of Enemy Types (4); easy, medium, hard, boss level
  - 2 levels for the players to choose from (min)
    
  - Home screen:
        - Game instructions
        - Towers available
        - Level-choosing options
    
  - Structure of the Game:
        - Keep the same original Game loop; start to finish with progressive rounds
        - round will change after specific number of enemy's have tried to pass through the level
        - Upgrades to Towers; attack-speed, increased-range, increased-damaged
        - upon death of each enemy --> add currency to player
        - Health bar and health total --> decrease total when enemy passes through the end of the level
        - At specific levels were harder enemy types show up, add a description of the enemy type

  - Enemy's:
        - Try to add ability for enemy's to destroy towers
              - Possible long rang attacks
              - Possible add enemy types that can bypass certain towers
        - Will follow a waypoint-style path towards the end of the level
    
