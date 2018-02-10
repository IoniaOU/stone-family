using UnityEngine;
using System.Collections;

public class Matrix {
	public int fakePercent = 10;
	
	private int x1, y1, x2, y2;
	
	public int getX1() {
		return x1;
	}
	
	
	public int getY1() {
		return y1;
	}
	
	
	public int getX2() {
		return x2;
	}
	
	
	public int getY2() {
		return y2;
	}
	
	public Cell[,] getMatrix(int rank){
		Cell[,] matrix = new Cell[rank, rank];
		
		for (int i = 0; i < rank; i++) {
            for (int j = 0; j < rank; j++) {
                matrix[i, j] = new Cell();
            }
        }
		
		int pathPercent = 25;
		
		int x = Random.Range(0, rank);
		
		x1 = x;
		y1 = 0;
		
		matrix[0,x].setMainPath(true);
		matrix[0,x].setPath(true);
		
		for (int i = 0; i < rank; i++) {
            int mainRandom = Random.Range(0, 3);
            int tempX = x;
			
			//sola doğru
			for (int j = tempX - 1; j >= 0; j--) {
                int tempRandom = Random.Range(0, 100);
                
                if(tempRandom <= pathPercent) {
                    break;
                }
                
                matrix[i, j].setPath(tempRandom > pathPercent ? true : false);
                matrix[i, j].setMainPath(mainRandom == 0 ? true : false);

                if(mainRandom == 0) {
                    x = j;
                }
			}
			// sağa doğru
			for (int j = tempX + 1; j < rank; j++) {
                int tempRandom = Random.Range(0, 100);
                
                if(tempRandom <= pathPercent) {
                    break;
                }
                
                matrix[i, j].setPath(tempRandom > pathPercent ? true : false);
                matrix[i, j].setMainPath(mainRandom == 2 ? true : false);

                if(mainRandom == 2) {
                    x = j;
                }
            }
			
			 if(i < rank - 1) {
                matrix[i + 1, x].setMainPath(true);
                matrix[i + 1, x].setPath(true);
            }
		}
		
		x2 = x;
		y2 = rank-1;
		
		return matrix;
	}
	
	
	
                }

