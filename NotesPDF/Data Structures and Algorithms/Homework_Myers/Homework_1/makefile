proj_1.x: tvector.h.gch driver.o
	g++ -std=c++17 tvector.h.gch driver.o -o proj_1.x

tvector.h.gch: tvector.h
	g++ -std=c++17 -c tvector.h

driver.o: driver.cpp
	g++ -std=c++17 -c driver.cpp

clean:
	rm -f *.o *.gch proj_1.x
