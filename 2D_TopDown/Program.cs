using System;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Topdown Game");
Raylib.SetTargetFPS(60);

Texture2D playerImage = Raylib.LoadTexture("gubbe.png");
Texture2D enemyImage = Raylib.LoadTexture("amogus.png");

//float x = 4.5f;

//float y = 10;

//int z = (int) 4.6f;

Rectangle playerRect = new Rectangle(10, 10, playerImage.width, playerImage.height);
Rectangle enemyRect = new Rectangle(100, 159, enemyImage.width, enemyImage.height);
Rectangle overlap = Raylib.GetCollisionRec(playerRect, enemyRect);

bool areOverlapping = Raylib.CheckCollisionRecs(playerRect, enemyRect);

while (!Raylib.WindowShouldClose())
{

int speed = 3;

        if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
    {
        playerRect.x += speed;
    }

    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
    {
        playerRect.x -= speed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
    {
        playerRect.y -= speed;
    }
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
    {
        playerRect.y += speed;
    }


    Raylib.BeginDrawing();


    Raylib.ClearBackground(Color.BLACK);
    Raylib.DrawRectangleRec(playerRect, Color.BLUE);
    Raylib.DrawRectangleRec(enemyRect, Color.RED);
    Raylib.DrawRectangleRec(overlap, Color.PURPLE);

    Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.BLUE);
    Raylib.DrawTexture(enemyImage, (int)enemyRect.x, (int) enemyRect.y, Color.RED);


    Raylib.EndDrawing();

}