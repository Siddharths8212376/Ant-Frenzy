# Ant-Frenzy
___

A 2D hyper-casual game for children.


## Instructions and Game Procedure
___

The player has to kill 30 ants in each level.

There is a time bound of 60 seconds for each level.

There is a limit of ant's that can spawn on the screen as well, specified by an ant limit counter on the screen.

Procedure:

**`if time == 0 and numberOfAntsOnScreen != 0 :`**

   **`endgame()`**

**`else if numberOfAntsOnScreen == LIMIT:`**

   **`endgame()`**

**`else if numberOfAntsKilled == LIMIT and time != 0:`**

   **`wingame()`**

___
