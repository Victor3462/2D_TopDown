using System;
using Raylib_cs;

Raylib.InitWindow(800, 600, "Topdown Game");
Raylib.SetTargetFPS(60);

Texture2D playerImage = Raylib.LoadTexture("1499636.jpg");

//float x = 4.5f;

//float y = 10;

//int z = (int) 4.6f;

Rectangle playerRect = new Rectangle(10, 10, 32, 32);

while (!Raylib.WindowShouldClose())
{

    Raylib.BeginDrawing();

    //Raylib.DrawRectangle(10,10,32,32, Color.DARKPURPLE);

    Raylib.DrawTexture(playerImage, 25, 25, Color.RED);

    Raylib.ClearBackground(Color.BLUE);


    Raylib.EndDrawing();

}