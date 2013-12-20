//
//  Game_Tank_Standard.cpp
//  Prosjekt-Tanks
//
//  Created by Geir Eivind Mork on 19.11.11.
//  Copyright 2011 __MyCompanyName__. All rights reserved.
//

#include <iostream>
#include "Game_Tank.h"
#include "Game_Tank_Standard.h"
#include "Game_TileEngine.h"
#include "App.h"

namespace Engine {
    Game_Tank_Standard::Game_Tank_Standard() {
        sTankImage1 = "tank_base01.png";
        sTankImage2 = "tank_base02.png";
        iTankCurrentSpeed = 0;
        iTankMaxSpeed = 20.f;
        iTankCurrentHealth = iTankMaxHealth = 100;
        iTankCurrentDirection = 90;
        iTankTurrentDirection = 90;
        
        //   oApp->sfDataManager.AddImage("Splash", "Graphics/SplashScreen.png", DataLoadImmediate);
    }
    Game_Tank_Standard::~Game_Tank_Standard() {
        
    }
    void Game_Tank_Standard::AddAppPointer(App* inApp) {
        oApp = inApp;
    }
    
    void Game_Tank_Standard::AddTileEnginePointer(Game_TileEngine* inTileEngine) {
        oTileEngine = inTileEngine;
    }  // connect the tile engine with the tank
    
    void Game_Tank_Standard::DoInit() {
        oApp->sfDataManager.AddImage("TankA", "Graphics/tank_base01.png", DataLoadImmediate);
        oApp->sfDataManager.AddImage("TankB", "Graphics/tank_base02.png", DataLoadImmediate);
        oApp->sfDataManager.AddImage("TankT", "Graphics/tank_top01.png", DataLoadImmediate);
        
        // Gets the sprites
        sfTankImage1 = oApp->sfDataManager.GetSprite("TankA"); // One of the anims
        sfTankImage1->SetPosition(20.f, 20.f);
        sfTankImage1->SetCenter(26.f, 26.f);
        sfTankImage2 = oApp->sfDataManager.GetSprite("TankB"); // Second anim
        sfTankImage2->SetPosition(20.f, 20.f);
        sfTankImage2->SetCenter(26.f, 26.f);
        sfTankTurret = oApp->sfDataManager.GetSprite("TankT"); // the turrent
        sfTankTurret->SetPosition(20.f, 20.f);
        sfTankTurret->SetCenter(36.f, 36.f);
        
        TurretDirection     = 3;    // start in the direction the image is oritented
        TankDirection       = 3;
    }
    void Game_Tank_Standard::Cleanup() {
        delete sfTankImage1;
        sfTankImage1 = NULL;
        delete sfTankImage2;
        sfTankImage2 = NULL;
        delete sfTankTurret;
        sfTankTurret = NULL;
        
        oApp->sfDataManager.UnloadImage("TankA");   // remove images from memory
        oApp->sfDataManager.UnloadImage("TankB");
        oApp->sfDataManager.UnloadImage("TankT");
        
    }
    void Game_Tank_Standard::ReInit() {
        
    }
    void Game_Tank_Standard::Update() {
    }
    
    void Game_Tank_Standard::MoveUp() {
        int const DIR_LEFT = 1, DIR_RIGHT = 2, DIR_UP = 3, DIR_DOWN = 4; 
        if (TankDirection != DIR_UP) {
            int angle = 0;
            
            switch (TankDirection) {
                case DIR_RIGHT:
                    angle = 90;
                    break;
                case DIR_LEFT:
                    angle = -90;
                    break;
                case DIR_DOWN:
                    angle = 180;
                    break;
            }
            TankDirection = DIR_UP;
            sfTankImage1->Rotate(angle);                
            sfTankImage2->Rotate(angle);                
        }
        if (sfTankImage1->GetPosition().y > 200) {
            sfTankImage1->Move(0, -iTankMaxSpeed);
            sfTankImage2->Move(0, -iTankMaxSpeed);
            sfTankTurret->Move(0, -iTankMaxSpeed);
        } else {
            oTileEngine->MoveUp(iTankMaxSpeed);
        }
        bTankMovement=bTankMovement?false:true;
        
    }
    void Game_Tank_Standard::MoveDown() { 
        int const DIR_LEFT = 1, DIR_RIGHT = 2, DIR_UP = 3, DIR_DOWN = 4; 
        if (TankDirection != DIR_DOWN) {
            int angle = 0;
            
            switch (TankDirection) {
                case DIR_RIGHT:
                    angle = -90;
                    break;
                case DIR_LEFT:
                    angle = 90;
                    break;
                case DIR_UP:
                    angle = -180;
                    break;
            }
            TankDirection = DIR_DOWN;
            sfTankImage1->Rotate(angle);                
            sfTankImage2->Rotate(angle);                
        }
        if (sfTankImage1->GetPosition().y < 400) {
            sfTankImage1->Move(0, iTankMaxSpeed);
            sfTankImage2->Move(0, iTankMaxSpeed);
            sfTankTurret->Move(0, iTankMaxSpeed);
        } else {
            oTileEngine->MoveDown(iTankMaxSpeed);
        }
        bTankMovement=bTankMovement?false:true;        
        
    }
    void Game_Tank_Standard::MoveLeft() {
        int const DIR_LEFT = 1, DIR_RIGHT = 2, DIR_UP = 3, DIR_DOWN = 4; 
        if (TankDirection != DIR_LEFT) {
            int angle = 0;
            
            switch (TankDirection) {
                case DIR_RIGHT:
                    angle = -180;
                    break;
                case DIR_UP:
                    angle = 90;
                    break;
                case DIR_DOWN:
                    angle = -90;
                    break;
            }
            TankDirection = DIR_LEFT;
            sfTankImage1->Rotate(angle);                
            sfTankImage2->Rotate(angle);                
        }
        if (sfTankImage1->GetPosition().x > 200) {
            sfTankImage1->Move(-iTankMaxSpeed, 0);
            sfTankImage2->Move(-iTankMaxSpeed, 0);
            sfTankTurret->Move(-iTankMaxSpeed, 0);
        } else {
            oTileEngine->MoveLeft(iTankMaxSpeed);
        }
        bTankMovement=bTankMovement?false:true;
        
    }
    void Game_Tank_Standard::MoveRight() { 
        int const DIR_LEFT = 1, DIR_RIGHT = 2, DIR_UP = 3, DIR_DOWN = 4; 
        if (TankDirection != DIR_RIGHT) {
            int angle = 0;
            
            switch (TankDirection) {
                case DIR_LEFT:
                    angle = 180;
                    break;
                case DIR_UP:
                    angle = -90;
                    break;
                case DIR_DOWN:
                    angle = 90;
                    break;
            }
            TankDirection = DIR_RIGHT;
            sfTankImage1->Rotate(angle);                
            sfTankImage2->Rotate(angle);                
        }
        if (sfTankImage1->GetPosition().x < 400) {
            sfTankImage1->Move(iTankMaxSpeed, 0);
            sfTankImage2->Move(iTankMaxSpeed, 0);
            sfTankTurret->Move(iTankMaxSpeed, 0);
        } else {
            oTileEngine->MoveRight(iTankMaxSpeed);
        }
        bTankMovement=bTankMovement?false:true;        
        
    }
    
    void Game_Tank_Standard::MoveTurretUp() {
        int const DIR_LEFT = 1, DIR_RIGHT = 2, DIR_UP = 3, DIR_DOWN = 4; 
        if (TurretDirection != DIR_UP) {
            int angle = 0;
            
            switch (TurretDirection) {
                case DIR_RIGHT:
                    angle = 90;
                    break;
                case DIR_LEFT:
                    angle = -90;
                    break;
                case DIR_DOWN:
                    angle = 180;
                    break;
            }
            TurretDirection = DIR_UP;
            sfTankTurret->Rotate(angle);
        }
        
    }
    void Game_Tank_Standard::MoveTurretDown() { 
        int const DIR_LEFT = 1, DIR_RIGHT = 2, DIR_UP = 3, DIR_DOWN = 4; 
        if (TurretDirection != DIR_DOWN) {
            int angle = 0;
            
            switch (TurretDirection) {
                case DIR_RIGHT:
                    angle = -90;
                    break;
                case DIR_LEFT:
                    angle = 90;
                    break;
                case DIR_UP:
                    angle = -180;
                    break;
            }
            TurretDirection = DIR_DOWN;
            sfTankTurret->Rotate(angle);
        }
        
    }
    void Game_Tank_Standard::MoveTurretLeft() {
        int const DIR_LEFT = 1, DIR_RIGHT = 2, DIR_UP = 3, DIR_DOWN = 4; 
        if (TurretDirection != DIR_LEFT) {
            int angle = 0;
            
            switch (TurretDirection) {
                case DIR_RIGHT:
                    angle = -180;
                    break;
                case DIR_UP:
                    angle = 90;
                    break;
                case DIR_DOWN:
                    angle = -90;
                    break;
            }
            TurretDirection = DIR_LEFT;
            sfTankTurret->Rotate(angle);
        }
        
    }
    void Game_Tank_Standard::MoveTurretRight() { 
        int const DIR_LEFT = 1, DIR_RIGHT = 2, DIR_UP = 3, DIR_DOWN = 4; 
        if (TurretDirection != DIR_RIGHT) {
            int angle = 0;
            
            switch (TurretDirection) {
                case DIR_LEFT:
                    angle = 180;
                    break;
                case DIR_UP:
                    angle = -90;
                    break;
                case DIR_DOWN:
                    angle = 90;
                    break;
            }
            TurretDirection = DIR_RIGHT;
            sfTankTurret->Rotate(angle);
        }
        
    }
    
    
    
    void Game_Tank_Standard::Draw() {
        if (bTankMovement) {
            oApp->sfRenderWindow.Draw(*sfTankImage1); // draws the tank image 1            
        } else {
            oApp->sfRenderWindow.Draw(*sfTankImage2); // draws the tank image 2                        
        }
        oApp->sfRenderWindow.Draw(*sfTankTurret); // draws the tank turret                        
    }
    
};