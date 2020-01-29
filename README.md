# GameOfLife2
An extension to the "Game of Life" cellular automaton.

This repository is my solution to the game of life challenge question posted on Reddit [here](https://www.reddit.com/r/dailyprogrammer/comments/6bumxo/20170518_challenge_315_intermediate_game_of_life). The idea was to extend the [Conway's Game of Life](https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life) cellular automaton with a second kind of entity, and a new ruleset. 

![](http://i.imgur.com/Lr37tMz.png)

Quoting the Reddit page, the rules for this automaton are as follows:

> 1. If a cell is 'off' but exactly 3 of its neighbours are on, that cell will also turn on - like reproduction.
> 2. If a cell is 'on' but less than two of its neighbours are on, it will die out - like underpopulation.
> 3. If a cell is 'on' but more than three of its neighbours are on, it will die out - like overcrowding.
> 4. When a cell has neighbours that are not of his own 1 of two things can happen:
>  - The total amount of cells in his neighbourhood of his color (including himself) is greater then the amount of cells not in his color in his neighbourhood 
>    -> apply normal rules, meaning that you have to count in the cells of other colors as alive cells
>  - If the amout of the other colors is greater then amount of that cell's own color then it just changes color.


Repository Info
--
This repository is a Unity 5 project.
