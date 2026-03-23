# War Card Game Simulation (C#)

## Overview

Console simulation of the card game **War** written in **C# using object‑oriented design**. The program supports **2–4 players** and runs until one player holds all cards or a **10,000 round limit** is reached.

---

## Main Classes

| Class     | Purpose                                                |
| --------- | ------------------------------------------------------ |
| `Card`    | Represents a playing card (Suit + Rank)                |
| `Deck`    | Builds and shuffles a 52‑card deck using `Stack<Card>` |
| `Hand`    | Stores player cards using `Queue<Card>`                |
| `WarGame` | Game logic and round handling                          |
| `Program` | Console entry point                                    |

Required structures used:

* `Stack<Card>` – deck
* `Queue<Card>` – player hands
* `Dictionary<string, Hand>` – player hands
* `Dictionary<string, Card>` – cards played per round
* `List<Card>` – shared pot

---

## Build

Requires **.NET 6+**.

```
dotnet build
```

---

## Run

```
dotnet run
```

You will be prompted for the number of players:

```
Enter number of players (2-4): 3
```

Players are automatically named **Player 1, Player 2, etc.**

---

## Game Rules

Rank order:

```
2 3 4 5 6 7 8 9 10 J Q K A
```

* All players reveal their top card each round
* Highest rank wins the round
* Ties trigger a **tiebreaker** where tied players reveal another card
* All cards go into a **shared pot**
* The winner collects the entire pot
* Players with **0 cards** are eliminated

---

## Round Limit

The game stops after **10,000 rounds**. The player with the most cards wins. If tied, the game ends in a draw.

---

## GitHub Classroom

Submitted through GitHub Classroom.

Repository:

```
https://github.com/etsucs-scott/project-2-mooreb9/
```

---

## Author

Ben Moore
CSCI 1260 – War Card Game Simulation

