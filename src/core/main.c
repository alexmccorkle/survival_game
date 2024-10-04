// Imports:

#include <stdio.h>
#include <stdlib.h>
#include <time.h>

#define MAX_HEALTH 100
#define MAX_HUNGER 100

// Creates a new data structure called Player
typedef struct
{
  int health;
  int hunger;
} Player;

// Void is same as in Java, it does not return anything
void initializePlayer(Player *player)
{
  player->health = MAX_HEALTH;
  player->hunger = MAX_HUNGER;
}

void updatePlayerStatus(Player *player)
{
  player->hunger -= 5;
  if (player->hunger < 0)
  {
    player->hunger = 0;
    player->health -= 5;
  }
  if (player->health < 0)
  {
    player->health = 0;
  }
}

void displayStatus(Player player)
{
  printf("Health: %d/%d\n", player.health, MAX_HEALTH);
  printf("Hunger: %d/%d\n", player.hunger, MAX_HUNGER);
}

int main()
{
  Player player;
  int turns = 0;

  srand(time(NULL));
  initializePlayer(&player);

  while (player.health > 0)
  {
    turns++;
    printf("\n--- Turn %d ---\n", turns);
    displayStatus(player);

    printf("1. Search for Food \n");
    printf("2. Rest \n");
    printf("Enter your choice: ");

    int choice;
    scanf("%d", &choice);

    switch (choice)
    {
    case 1:
      if (rand() % 2 == 0)
      {
        printf("You found some food! \n");
        player.hunger += 20;
        if (player.hunger > MAX_HUNGER)
        {
          player.hunger = MAX_HUNGER;
        }
        else
        {
          printf("You couldn't find any food! \n");
        }
        break;
      }
    case 2:
      printf("You rest for a while");
      player.health += 10;
      if (player.health > MAX_HEALTH)
      {
        player.health = MAX_HEALTH;
      }
      break;
    default:
      printf("Invalid choice. Skipping turn.\n");
    }

    updatePlayerStatus(&player);
  }

  printf("\n Game over! You survived for %d turns.\n", turns);

  return 0;
}