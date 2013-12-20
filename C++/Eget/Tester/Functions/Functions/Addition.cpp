#include <iostream>
#include "Header.h"
#include <string>

int main()
{
int x;
x= addition(5,7);//			X is here
std::cout<<"the number is "<<x<<std::endl;

std::cout<<txt("word1", "word2")<<std::endl<<std::endl;

baws();

std::cout<<setY(777)<<std::endl;




//end stuff
std::system("PAUSE");return EXIT_SUCCESS;}

int addition (int a, int b)
{
	int z= a*b;
	return z;

}

std::string txt (std::string c, std::string d)
{

	return c+" "+d;
}

void baws()
{
	std::cout<<"IM DA BAWS!"<<std::endl;
}
