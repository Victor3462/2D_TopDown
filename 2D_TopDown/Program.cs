using System;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Topdown Game");
Raylib.SetTargetFPS(60);

Texture2D playerImage = Raylib.LoadTexture("amogus.png");
Texture2D ventImage = Raylib.LoadTexture("vent.png");

//float x = 4.5f;

//float y = 10;

//int z = (int) 4.6f;

Rectangle playerRect = new Rectangle(10, 10, playerImage.width, playerImage.height);
Rectangle ventRect = new Rectangle(400, 375, ventImage.width, ventImage.height);
Rectangle overlap = Raylib.GetCollisionRec(playerRect, ventRect);


Color pcolor = Color.BLUE;
Color ecolor = Color.RED;
Color ocolor = Color.PURPLE;

string room = "1";

while (!Raylib.WindowShouldClose())
{

    int speed = 3;

    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT))
    {
        speed = 5;
    }

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

    if (room == "1")
    {


        bool areOverlapping = Raylib.CheckCollisionRecs(playerRect, ventRect);

        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawRectangleRec(playerRect, pcolor);
        Raylib.DrawRectangleRec(ventRect, ecolor);

        Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.BLUE);
        Raylib.DrawTexture(ventImage, (int)ventRect.x, (int)ventRect.y, Color.RED);

        if (areOverlapping == true)
        {
            room = "2";
        }

    }

    if (room == "2")
    {
        Raylib.ClearBackground(Color.GRAY);
        Raylib.DrawRectangleRec(playerRect, pcolor);

        Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.BLUE);

    }










    Raylib.EndDrawing();

}