using System;
using Raylib_cs;
using System.Collections.Generic;

Raylib.InitWindow(800, 600, "Topdown Game");
Raylib.SetTargetFPS(60);

Texture2D playerImage = Raylib.LoadTexture("amogus.png");
Texture2D ventImage = Raylib.LoadTexture("vent.png");

Rectangle playerRect = new Rectangle(10, 10, playerImage.width, playerImage.height);
Rectangle ventRect = new Rectangle(625, 375, ventImage.width, ventImage.height);
Rectangle overlap = Raylib.GetCollisionRec(playerRect, ventRect);

Rectangle pointRec = new Rectangle(80, 375, 18, 18);
Rectangle overlapPoint = Raylib.GetCollisionRec(playerRect, pointRec);

Color pcolor = Color.BLUE;
Color ecolor = Color.RED;
Color ocolor = Color.PURPLE;
Color pointcolor = Color.LIME;

string room = "Lobby";

int pointsint = 0;

bool pointCollected = false;

while (!Raylib.WindowShouldClose())
{

    int speed = 3;

    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT_SHIFT)) speed = 5;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_D)) playerRect.x += speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_A)) playerRect.x -= speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_W)) playerRect.y -= speed;
    if (Raylib.IsKeyDown(KeyboardKey.KEY_S)) playerRect.y += speed;
    
    if (playerRect.x < 0) playerRect.x = 0;
    if (playerRect.y < 0) playerRect.y = 0;
    if (playerRect.x > 800 - playerRect.width) playerRect.x = 800 - playerRect.width;
    if (playerRect.y > 600 - playerRect.height) playerRect.y = 600 - playerRect.height;
    
    Raylib.BeginDrawing();

    Raylib.DrawText(room, 350, 10, 20, Color.WHITE);
    Raylib.DrawText(pointsint.ToString(), 20, 10, 40, Color.WHITE);


    if (room == "Lobby")
    {
        bool areOverlapping = Raylib.CheckCollisionRecs(playerRect, ventRect);
        bool pointOverlapping = Raylib.CheckCollisionRecs(playerRect, pointRec);

        Raylib.ClearBackground(Color.BLACK);
        Raylib.DrawRectangleRec(playerRect, pcolor);
        Raylib.DrawRectangleRec(ventRect, ecolor);
        
        if (pointCollected == false)
        {
            Raylib.DrawRectangleRec(pointRec, pointcolor);
        }

        Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.BLUE);
        Raylib.DrawTexture(ventImage, (int)ventRect.x, (int)ventRect.y, Color.RED);

        if (areOverlapping == true)
        {
            room = "Hallway";
        }
        else if (pointOverlapping == true && pointCollected == false)
        {
            pointsint++;
            pointCollected = true;
        }

    }

    if (room == "Hallway")
    {
        Raylib.ClearBackground(Color.DARKGRAY);
        Raylib.DrawRectangleRec(playerRect, pcolor);

        Raylib.DrawTexture(playerImage, (int)playerRect.x, (int)playerRect.y, Color.BLUE);

    }
    
    
    
    Raylib.EndDrawing();


}