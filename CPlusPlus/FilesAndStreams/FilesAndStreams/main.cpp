#include <iostream>
#include <string>
#include <vector>
#include <fstream>

std::vector<char> ReadBinaryFile(std::string fileName)
{
	std::ifstream input(fileName, std::ios::binary);
	std::vector<char> content((
		std::istreambuf_iterator<char>(input)),
		(std::istreambuf_iterator<char>()));
	return content;
}

void WriteBinaryFile(std::string fileName, std::vector<char> data)
{
	std::ofstream output(fileName, std::ios::binary);
	std::copy<std::vector<char>::iterator, std::ostreambuf_iterator<char>>(
		data.begin(),
		data.end(),
		output);
}

void main()
{
	std::vector<char> data = ReadBinaryFile("song.bin");

	std::cout << "Before:";
	for (std::vector<char>::iterator it = data.begin(); it != data.end(); it++)
	{
		std::cout << *it;
	}
	std::cout << std::endl;

	data.push_back(65);
	data.erase(data.begin());
	data[2] = 66;

	std::cout << "After :";
	for (std::vector<char>::iterator it = data.begin(); it != data.end(); it++)
	{
		std::cout << *it;
	}
	std::cout << std::endl;

	WriteBinaryFile("song.bin", data);

	system("pause");
}