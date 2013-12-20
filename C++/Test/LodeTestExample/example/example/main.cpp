#include <iostream>
#include <iomanip>

#include <iostream>
#include <cmath>
#include <vector>
#include "lodepng.h"





int main()
{
	 //generate some image
  const int w = 2048;
  const int h = 2048;
  
  std::vector<unsigned char> image;
  image.resize(w * h*4);
  for(int y = 0; y < h; y++)
  {
	  for(int x = 0; x < w; x++)
	  {
		//pattern 1
		image[4 * w * y + 4 * x + 0] = (unsigned char)(127 * (1 + std::sin((                    x * x +                     y * y) / (w * h / 8.0))));
		image[4 * w * y + 4 * x + 1] = (unsigned char)(127 * (1 + std::sin(((w - x - 1) * (w - x - 1) +                     y * y) / (w * h / 8.0))));
		image[4 * w * y + 4 * x + 2] = (unsigned char)(127 * (1 + std::sin((                    x * x + (h - y - 1) * (h - y - 1)) / (w * h / 8.0))));
		image[4 * w * y + 4 * x + 3] = (unsigned char)(127 * (1 + std::sin(((w - x - 1) * (w - x - 1) + (h - y - 1) * (h - y - 1)) / (w * h / 8.0))));
    
		//pattern 2
		//image[4 * w * y + 4 * x + 0] = 255 * !(x & y);
		//image[4 * w * y + 4 * x + 1] = x ^ y;
		//image[4 * w * y + 4 * x + 2] = x | y;
		//image[4 * w * y + 4 * x + 3] = 255;
	  }
  }
  //create encoder and set settings and info (optional)
  
  LodePNG::Encoder encoder;
  encoder.addText("Comment", "Created with LodePNG");
  encoder.getSettings().zlibsettings.windowSize = 2048;

  //encode and save
  std::vector<unsigned char> buffer;
  encoder.encode(buffer, image.empty() ? 0 : &image[0], w, h);
  LodePNG::saveFile(buffer, "Output.png");




  return EXIT_SUCCESS;
}