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
#include "App.h"
#include "Game_TileEngine.h"
#include <sstream>
#include <fstream>
#include <vector>


namespace Engine {
    Game_TileEngine::Game_TileEngine() :
        NUMBER_OF_TILES(5) // Also remember to change the sfTile in the header file
    {
        iViewPortX = iViewPortY = 0;
    }
    Game_TileEngine::~Game_TileEngine() 
    {
        
    }
    void Game_TileEngine::AddAppPointer(App* inApp) 
    {
        oApp = inApp;
    }

    // Initalizing the TileEngine class
    void Game_TileEngine::DoInit()
    {
        // Loads the tiles
        for (int i=0; i<NUMBER_OF_TILES; i++) {            
            std::stringstream ss;
            ss << "Graphics/Tile" << i << ".png";
            std::cout << "Adding tile " << ss.str() << std::endl;
            oApp->sfDataManager.AddImage("Tile" + i, ss.str(), DataLoadImmediate);
            sfTile[i] = oApp->sfDataManager.GetSprite("Tile" + i);
        }
        
        std::string tempmapstring;          // temp string for map
        std::fstream map;                   // fstream for map
        
        int SlashCounter=0;                 // Counts how many linechange signs there are
        
        map.open("Maps/FreeForAll_01.txt");
                       
        if ( !map.is_open() )
        {
            std::cout << "game_tileengine: failed to loap map" << std::endl; 
            exit(StatusError);
        }
        // Goes through the map file and makes a string with '/'as linebreakers
        while(!(map.eof()))
        {
            getline(map, tempmapstring);
            mapstring+=tempmapstring+'/';   // makes a sign which makes the tile change line
            SlashCounter++;                 // Counts how many linechange signs there are
        }
        std::cout << mapstring << std::endl;    // prints out the tiles in the console with the '/'s
        std::cout << mapstring.length()-SlashCounter << std::endl;
                                            // Shows number of tiles total
        long iNumberOfSprites = mapstring.length();
        
        float Xposition=0.f;
        float Yposition=0.f;
        int Xmax    = 0;
        int Xtemp   = 0;
        int Ymax    = 0;
        //Goes through the map string and load them on the vector
        for(int c = 0; c < iNumberOfSprites; c++)
        {            
            int CaseChosen=0;
            Point p;
            
            if(mapstring.at(c) != '/')
            {
                std::stringstream ss;
                char CharGetCharacter = mapstring.at(c);
                std::string GetTheCharacter="4";    // Default
                ss<<CharGetCharacter;               // This converts a char to a number
                ss>>GetTheCharacter;			
                CaseChosen=atoi(GetTheCharacter.c_str());

                p.Tile = CaseChosen;
                p.x = Xposition;
                p.y = Yposition;
                                                    // If the map file is corrupted with letters it will just show
                                                    // a white tile/sprite where it was corrupted
                Xposition += 16.f;
                Xtemp+=16;
            } else {
                Ymax+=16;
                Yposition += 16.f;
                Xposition = 0.f;
                if (Xtemp > Xmax) Xmax = Xtemp;
                Xtemp = 0;
            }
            sfPointVector.push_back(p);
        }
                
        sfBackgroundImage.Create(Xmax, Ymax, sf::Color(0, 0, 0));
        
        sf::IntRect r1(0, 0, 16, 16);
        
        for (int i = 0; i<sfPointVector.size(); i++) {
            
//            sfTile[ sfPointVector[ i ].Tile ]->SetPosition( sfPointVector[i].x, sfPointVector[i].y );                                                         
            
//            Copy (const Image &Source, unsigned int DestX, unsigned int DestY, const IntRect &SourceRect=IntRect(0, 0, 0, 0), bool ApplyAlpha=false)
            sfBackgroundImage.Copy(*sfTile[ sfPointVector[i].Tile ]->GetImage(),sfPointVector[i].x,sfPointVector[i].y,r1);
/*            oApp->sfRenderWindow.Draw(
                                      *sfTile[ sfPointVector[i].Tile ] 
                                      ); // draws the tiles   */
        }
        sfBackgroundSprite.SetImage(sfBackgroundImage);
        
    }
    void Game_TileEngine::MoveUp(float speed)      // Movies the viewport UP direction
    {
        iViewPortY-=speed;
    }
    void Game_TileEngine::MoveDown(float speed)    // Movies the viewport Down direction
    {
        iViewPortY+=speed;
    }
    void Game_TileEngine::MoveLeft(float speed)    // Movies the viewport Left direction
    {
        iViewPortX-=speed;        
    }
    void Game_TileEngine::MoveRight(float speed)   // Movies the viewport Right direction    
    {
        iViewPortX+=speed;
    }
    
    
      // handles restart of TileEngine class (You know, reset everything)
    void Game_TileEngine::ReInit() 
    {
            // not implemented yet. take the creation in doinit out in a private function
            // and reload the map maybe? 
    }
    // handle the update when it's active
    void Game_TileEngine::Update()
    {
        // I would guess we here would put the stuff that loads the tilemap around where we are. 
    }

    // Handle the drawing needs
    void Game_TileEngine::Draw(sf::Vector2f pos)
    {
/*        sf::FloatRect fr = DefaultView.GetRect();
        std::cout << "l: " << fr.Left
                  << "r: " << fr.Right
                  << "u: " << fr.Top
        << "d: " << fr.Bottom << std::endl;*/
      /*  for (int i = 0; i<sfPointVector.size(); i++) {
            
            sfTile[ sfPointVector[ i ].Tile ]->SetPosition( sfPointVector[i].x, sfPointVector[i].y );                                                         
            
            oApp->sfRenderWindow.Draw(
             *sfTile[ sfPointVector[i].Tile ] 
            ); // draws the tiles   
                        
        }*/
//        std::cout << "x: " <<iViewPortX << "x" << iViewPortY << ": " << (600+iViewPortX) << "x" << (600+iViewPortY) << std::endl;
        //sf::IntRect r1(iViewPortX, iViewPortY, 600+iViewPortX, 600+iViewPortY);
		sf::IntRect r1(iViewPortX, iViewPortY, 5800+iViewPortX, 5800+iViewPortY);
		std::cout<<"HELUUUUU: X:"<<iViewPortX<<"Y: "<<iViewPortY<<std::endl;
        sfBackgroundSprite.SetSubRect(r1);
        oApp->sfRenderWindow.Draw(sfBackgroundSprite);
    }
    
    
    // cleans up after
    void Game_TileEngine::Cleanup() 
    {
        // apparently delete[] doesn't work with sf:Sprite soo remember to update this with the number of tiles
        for (int i=0; i<NUMBER_OF_TILES; i++) {
            delete sfTile[i];
            sfTile[i] = NULL;
            std::cout << "Removed tile " << i << std::endl;
            oApp->sfDataManager.UnloadImage("Tile" + i);
        }        
    }
};
