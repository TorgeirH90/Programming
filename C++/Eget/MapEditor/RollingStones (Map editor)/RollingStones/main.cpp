#include <iostream>
#include <fstream>
#include "lodepng.h"



int main()
{

	std::vector<unsigned char> buffer, image, red,green,blue;
	std::vector<char> map;
	unsigned int hoyde=0;
	unsigned int bredde=0;
	int pixler=0;
	int r=0;
	int g=0;
	int b=0;
	int j=0;//Teller bredden til bildet
	int temporarytolastfor=0;
	std::string tempolastfor;
	std::string TheMap;
	//Åpne outputFil

	std::fstream output("output/OutputMap.txt");
	if(output.fail())
	{
		std::cout<<"The output file went wrong way"<<std::endl;
		system("pause");
		return EXIT_FAILURE;
	}



	//Åpne inputFila
	LodePNG::loadFile(buffer, "input/map.png");
	LodePNG::Decoder decoder;
	decoder.decode(image, buffer.empty() ? 0 : &buffer[0], (unsigned)buffer.size());
	if(decoder.hasError()) std::cout << "error " << decoder.getError() << ": " << LodePNG_error_text(decoder.getError()) << std::endl;
	
	else
	{
		hoyde=decoder.getHeight();
		bredde=decoder.getWidth();
		pixler=hoyde*bredde;
		for(int i=0;i<=pixler-1;i++)
		{
			std::cout<<i<<std::endl;
			red.push_back(image[i*4]);//R
			
			green.push_back(image[(i*4)+1]);//G
			
			blue.push_back(image[(i*4)+2]);//B

			
			
		}


	}
	//int c=0;
	for(int i=0;i<=pixler-1;i++)
		{


			if(red[i]==63&&green[i]==72&&blue[i]==204)
				
			{
				std::cout<<i<<" is blue"<<std::endl;
				map.push_back('0');

			}
			else if(red[i]==255&&green[i]==242&&blue[i]==0)
				
			{
				std::cout<<i<<" is yellow"<<std::endl;
				map.push_back('1');
			}
			else if(red[i]==0&&green[i]==0&&blue[i]==0)
				
			{
				std::cout<<i<<" is black"<<std::endl;
				map.push_back('2');
			}
			else if(red[i]==237&&green[i]==28&&blue[i]==36)
				
			{
				std::cout<<i<<" is red"<<std::endl;
				map.push_back('3');
			}
			else if(red[i]==136&&green[i]==0&&blue[i]==21)
				
			{
				std::cout<<i<<" is brown"<<std::endl;
				map.push_back('4');
			}

			

			j++;
			if(j>=bredde)
			{
				map.push_back('/');
				j=0;
			}
		}


	std::cout<<"hoyde: "<<hoyde<<std::endl<<"bredde: "<<bredde<<std::endl;
	std::cout<<"map: "<<std::endl;

	for (int i=0;i<=map.size()-1;i++)
	{
		if(map[i]!='/')
		{
			tempolastfor=map[i];
			temporarytolastfor=atoi(tempolastfor.c_str());

		std::cout<<temporarytolastfor;
		output<<temporarytolastfor;
		}
		else
		{
			std::cout<<std::endl;
			output<<std::endl;
		}
	}

	output.close();

	std::cout<<"Hopefully successfull"<<std::endl;
	system("pause");

	return EXIT_SUCCESS;
}