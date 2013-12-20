//                                                  |  
//             [ O ]                                | 
//               \ \      p                         | 
//                \ \  \o/                          | 
//                 \ \--'---_                       |  
//                 /\ \   / ~~\_                    | 
//           ./---/__|=/_/------//~~~\              | 
//          /___________________/O   O \            | 
//          (===(\_________(===(Oo o o O)          
//           \~~~\____/     \---\Oo__o--            Sticks and Stones
//             ~~~~~~~       ~~~~~~~~~~              Might break my bones
//                                                  
// Changelog:
// 19/11/11  Created         Geir Eivind Mork

#include <iostream>
#include "engine_data.h"
#include "Data_Image.h"
#include "App.h"
#include "State_Game.h"
#include "Game_Tank.h"
#include "Game_Tank_Standard.h"
#include "Game_TileEngine.h"


namespace Engine {
    State_Game::State_Game(App* inApp) :
    StateInterface("Game",inApp),
    sfGameSprite(NULL) {}
    
    State_Game::~State_Game() {}    
    void State_Game::HandleEvents(sf::Event inEvent) {
        int const DIR_LEFT = 1, DIR_RIGHT = 2, DIR_UP = 3, DIR_DOWN = 4; 
        
        if ((inEvent.Type == sf::Event::KeyReleased) && (inEvent.Key.Code == sf::Key::W ||
                                                        inEvent.Key.Code == sf::Key::A ||
                                                         inEvent.Key.Code == sf::Key::S ||
                                                         inEvent.Key.Code == sf::Key::D)) {
            std::cout << "key released " << std::endl;
            switch (inEvent.Key.Code) {
                case sf::Key::W:
                    if (iDirKeyDown == DIR_UP)             
                        iDirKeyDown = 0;
                    break;
                case sf::Key::A:
                    if (iDirKeyDown == DIR_LEFT)             
                        iDirKeyDown = 0;
                    break;
                case sf::Key::S:
                    if (iDirKeyDown == DIR_DOWN)             
                        iDirKeyDown = 0;
                    break;
                case sf::Key::D:
                    if (iDirKeyDown == DIR_RIGHT)             
                        iDirKeyDown = 0;
                    break;
                default:
                    break;
            }
        }
        if (inEvent.Type == sf::Event::KeyPressed) {
            // Escape key pressed, quits the app
            if (inEvent.Key.Code == sf::Key::Escape)
            {
                if(oApp != NULL)
                {
                    oApp->Quit(StatusOK);
                }
            }
            // tank movement
            if (inEvent.Key.Code == sf::Key::W)
            {
                if(oApp != NULL)
                {
                    iDirKeyDown = DIR_UP;
                }
            } 
            if (inEvent.Key.Code == sf::Key::S)
            {
                if(oApp != NULL)
                {
                    iDirKeyDown = DIR_DOWN;
                }
            } 
            if (inEvent.Key.Code == sf::Key::A)
            {
                if(oApp != NULL)
                {
                    iDirKeyDown = DIR_LEFT;
                }
            } 
            if (inEvent.Key.Code == sf::Key::D)
            {
                if(oApp != NULL)
                {
                    iDirKeyDown = DIR_RIGHT;
                }
            }
            
            // turrent movement
            if (inEvent.Key.Code == sf::Key::Up)
            {
                if(oApp != NULL)
                {
                    // GameView.Move(0, -Offset);
                    gPlayerTank->MoveTurretUp();
                }
            }
            if (inEvent.Key.Code == sf::Key::Down)
            {
                if(oApp != NULL)
                {
                    // GameView.Move(0, Offset);                
                    gPlayerTank->MoveTurretDown();
                }
            }
            if (inEvent.Key.Code == sf::Key::Left)
            {
                if(oApp != NULL)
                {
                    // GameView.Move(-Offset, 0);                
                    gPlayerTank->MoveTurretLeft();
                }
            }
            if (inEvent.Key.Code == sf::Key::Right)
            {
                if(oApp != NULL)
                {
                    // GameView.Move(Offset, 0);                
                    gPlayerTank->MoveTurretRight();
                }
            }
        
        }        
    
    }
    void State_Game::DoInit()
    {
        StateInterface::DoInit();        // init the base class
                
        assert(oApp != NULL && "The state Game did get a bad pointer");
        
        // init the tile engine
        gTileEngine = new Game_TileEngine();
        gTileEngine->AddAppPointer(oApp);
        gTileEngine->DoInit();

        // Init the players tanks
        gPlayerTank = new Game_Tank_Standard();
        gPlayerTank->AddAppPointer(oApp);
        gPlayerTank->AddTileEnginePointer(gTileEngine);
        gPlayerTank->DoInit();
        

        // Loads the Game image
        oApp->sfDataManager.AddImage("HUD", "Graphics/HUD.png", DataLoadImmediate);
        
        // Retrieve a sprite to the above image
        sfGameSprite = oApp->sfDataManager.GetSprite("HUD");
        sfGameSprite->SetPosition(600.f, 0.f);
        
        // sets the views
        
        DefaultView = oApp->sfRenderWindow.GetDefaultView();
        //GameView.Zoom(0.2f);
		GameView.SetFromRect(DefaultView.GetRect());
        HudView.SetFromRect(DefaultView.GetRect());
		GameView.Zoom(0.1f);
		GameView.Move(3600,2700);
        //GameView.SetFromRect(sf::FloatRect(0, 0, 2000, 2000));
        //HudView.SetFromRect(sf::FloatRect(0, 0, 2000, 2000));

        // init the minimap
        gHUD = new Game_HUD();
        gHUD->AddAppPointer(oApp);
        gHUD->setMap(gTileEngine->sfBackgroundImage);
        gHUD->DoInit();
        
        
        
    }
    
    void State_Game::ReInit()
    {
        // Don't think we need a "see Game again" choice
    }
    
    void State_Game::Update()
    {
        int const DIR_LEFT = 1, DIR_RIGHT = 2, DIR_UP = 3, DIR_DOWN = 4; 
        assert(oApp != NULL && "State Game update has bad pointer");  // checks pointer
        gTileEngine->Update();
        gHUD->Update();
        
        // tank movement
        // the tank movements is initalized in the handle events but continued here. 
        switch (iDirKeyDown) {
            case DIR_UP:
                gPlayerTank->MoveUp();
                break;
            case DIR_DOWN:
                gPlayerTank->MoveDown();
                break;
            case DIR_LEFT:
                gPlayerTank->MoveLeft();
                break;
            case DIR_RIGHT:
                gPlayerTank->MoveRight();
                break;
        }
    }
    
    void State_Game::Draw()
    {
        assert(oApp != NULL && "State Game draw has bad pointer");  // checks pointer        
        oApp->sfRenderWindow.Clear();
        oApp->sfRenderWindow.SetView(GameView);
//        sf::Vector2f foo = GameView.GetCenter();
//        std::cout << foo.x << "x" << foo.y << std::endl;
        
        gTileEngine->Draw(gPlayerTank->GetPosition());
        gPlayerTank->Draw();

        oApp->sfRenderWindow.SetView(HudView);

        oApp->sfRenderWindow.Draw(*sfGameSprite); // Draws the HUD

        gHUD->Draw();   // draws whatever goes on the hud
        
        oApp->sfRenderWindow.SetView(DefaultView);

        
    }
    
    void State_Game::Cleanup()
    {
        delete sfGameSprite;        // Delete the Game screen
        sfGameSprite = NULL;

        gPlayerTank->Cleanup();
        delete gPlayerTank;         // Delete the players tank
        gPlayerTank = NULL;
        
        gTileEngine->Cleanup();
        
        oApp->sfDataManager.UnloadImage("HUD");  // Unloads and cleans up
        StateInterface::Cleanup();
    }
    
}