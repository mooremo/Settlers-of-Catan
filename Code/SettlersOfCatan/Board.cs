using System;
using System.Collections;
using System.Collections.Generic;

namespace SettlersOfCatan
{
    public class Board
    {
        #region Properties
        #region TileNeighborDictionary
        private readonly Dictionary<int, ArrayList> _neighborDictionary = new Dictionary<int, ArrayList>
                                                                              {
                                                                                  {
                                                                                      0,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            -1, 0, 3, 5,
                                                                                                            2,
                                                                                                            0
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      1,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            0, 1, 5, 7,
                                                                                                            4,
                                                                                                            -9
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      2,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            0, -2, 6, 8,
                                                                                                            5,
                                                                                                            1
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      3,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            -9, 2, 7, 9,
                                                                                                            -8
                                                                                                            , 0
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      4,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            1, 3, 8, 10,
                                                                                                            7,
                                                                                                            2
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      5,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            -2, 0, -3,
                                                                                                            11,
                                                                                                            8, 3
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      6,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            2, 5, 10, 12
                                                                                                            , 9
                                                                                                            , 4
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      7,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            3, 6, 11, 13
                                                                                                            ,
                                                                                                            10, 5
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      8,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            4, 7, 12, 14
                                                                                                            , 0
                                                                                                            , -8
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      9,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            5, 8, 13, 15
                                                                                                            ,
                                                                                                            12, 7
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      10,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            6, -3, 0, 16
                                                                                                            ,
                                                                                                            13, 8
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      11,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            7, 10, 15,
                                                                                                            17,
                                                                                                            14, 9
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      12,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            8, 11, 16,
                                                                                                            18,
                                                                                                            15, 10
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      13,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            9, 12, 17, 0
                                                                                                            ,
                                                                                                            -7, 0
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      14,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            10, 13, 18,
                                                                                                            19,
                                                                                                            17, 12
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      15,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            11, 0, -4, 0
                                                                                                            ,
                                                                                                            18, 13
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      16,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            12, 15, 19,
                                                                                                            -6,
                                                                                                            0, 14
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      17,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            13, 16, 0,
                                                                                                            -5,
                                                                                                            19, 15
                                                                                                        })
                                                                                      },
                                                                                  {
                                                                                      18,
                                                                                      new ArrayList(new[]
                                                                                                        {
                                                                                                            15, 18, -5,
                                                                                                            0,
                                                                                                            -6, 17
                                                                                                        })
                                                                                      }
                                                                              };

        #endregion

        #region VerticeNeighborDictionary
        private readonly Dictionary<int, ArrayList> _verticeDictionary = new Dictionary<int, ArrayList>
                                                                             {
                                                                                 {
                                                                                     0,
                                                                                     new ArrayList(new[] {1, 3, -1})
                                                                                     },
                                                                                 {
                                                                                     1,
                                                                                     new ArrayList(new[] {-1, 4, 0})
                                                                                     },
                                                                                 {
                                                                                     2,
                                                                                     new ArrayList(new[] {3, 7, -1})
                                                                                     },
                                                                                 {
                                                                                     3, new ArrayList(new[] {0, 8, 2})
                                                                                     },
                                                                                 {
                                                                                     4, new ArrayList(new[] {5, 9, 1})
                                                                                     },
                                                                                 {
                                                                                     5,
                                                                                     new ArrayList(new[]
                                                                                                       {-1, 10, 4})
                                                                                     },
                                                                                 {
                                                                                     6,
                                                                                     new ArrayList(new[]
                                                                                                       {7, 12, -1})
                                                                                     },
                                                                                 {
                                                                                     7,
                                                                                     new ArrayList(new[] {2, 13, 6})
                                                                                     },
                                                                                 {
                                                                                     8,
                                                                                     new ArrayList(new[] {9, 14, 3})
                                                                                     },
                                                                                 {
                                                                                     9,
                                                                                     new ArrayList(new[] {4, 15, 8})
                                                                                     },
                                                                                 {
                                                                                     10,
                                                                                     new ArrayList(new[]
                                                                                                       {11, 16, 5})
                                                                                     },
                                                                                 {
                                                                                     11,
                                                                                     new ArrayList(new[]
                                                                                                       {-1, 17, 10})
                                                                                     },
                                                                                 {
                                                                                     12,
                                                                                     new ArrayList(new[]
                                                                                                       {6, 18, -1})
                                                                                     },
                                                                                 {
                                                                                     13,
                                                                                     new ArrayList(new[]
                                                                                                       {14, 19, 7})
                                                                                     },
                                                                                 {
                                                                                     14,
                                                                                     new ArrayList(new[]
                                                                                                       {8, 20, 13})
                                                                                     },
                                                                                 {
                                                                                     15,
                                                                                     new ArrayList(new[]
                                                                                                       {16, 21, 9})
                                                                                     },
                                                                                 {
                                                                                     16,
                                                                                     new ArrayList(new[]
                                                                                                       {10, 22, 15})
                                                                                     },
                                                                                 {
                                                                                     17,
                                                                                     new ArrayList(new[]
                                                                                                       {-1, 22, 11})
                                                                                     },
                                                                                 {
                                                                                     18,
                                                                                     new ArrayList(new[]
                                                                                                       {19, 24, 12})
                                                                                     },
                                                                                 {
                                                                                     19,
                                                                                     new ArrayList(new[]
                                                                                                       {13, 25, 18})
                                                                                     },
                                                                                 {
                                                                                     20,
                                                                                     new ArrayList(new[]
                                                                                                       {21, 26, 14})
                                                                                     },
                                                                                 {
                                                                                     21,
                                                                                     new ArrayList(new[]
                                                                                                       {15, 27, 20})
                                                                                     },
                                                                                 {
                                                                                     22,
                                                                                     new ArrayList(new[]
                                                                                                       {23, 28, 16})
                                                                                     },
                                                                                 {
                                                                                     23,
                                                                                     new ArrayList(new[]
                                                                                                       {17, 29, 22})
                                                                                     },
                                                                                 {
                                                                                     24,
                                                                                     new ArrayList(new[]
                                                                                                       {18, 30, -1})
                                                                                     },
                                                                                 {
                                                                                     25,
                                                                                     new ArrayList(new[]
                                                                                                       {26, 31, 19})
                                                                                     },
                                                                                 {
                                                                                     26,
                                                                                     new ArrayList(new[]
                                                                                                       {20, 32, 25})
                                                                                     },
                                                                                 {
                                                                                     27,
                                                                                     new ArrayList(new[]
                                                                                                       {28, 33, 21})
                                                                                     },
                                                                                 {
                                                                                     28,
                                                                                     new ArrayList(new[]
                                                                                                       {22, 34, 27})
                                                                                     },
                                                                                 {
                                                                                     29,
                                                                                     new ArrayList(new[]
                                                                                                       {-1, 35, 23})
                                                                                     },
                                                                                 {
                                                                                     30,
                                                                                     new ArrayList(new[]
                                                                                                       {31, 36, 24})
                                                                                     },
                                                                                 {
                                                                                     31,
                                                                                     new ArrayList(new[]
                                                                                                       {25, 37, 30})
                                                                                     },
                                                                                 {
                                                                                     32,
                                                                                     new ArrayList(new[]
                                                                                                       {33, 38, 26})
                                                                                     },
                                                                                 {
                                                                                     33,
                                                                                     new ArrayList(new[]
                                                                                                       {27, 39, 32})
                                                                                     },
                                                                                 {
                                                                                     34,
                                                                                     new ArrayList(new[]
                                                                                                       {35, 40, 28})
                                                                                     },
                                                                                 {
                                                                                     35,
                                                                                     new ArrayList(new[]
                                                                                                       {29, 41, 34})
                                                                                     },
                                                                                 {
                                                                                     36,
                                                                                     new ArrayList(new[]
                                                                                                       {30, 42, -1})
                                                                                     },
                                                                                 {
                                                                                     37,
                                                                                     new ArrayList(new[]
                                                                                                       {38, 43, 31})
                                                                                     },
                                                                                 {
                                                                                     38,
                                                                                     new ArrayList(new[]
                                                                                                       {32, 44, 37})
                                                                                     },
                                                                                 {
                                                                                     39,
                                                                                     new ArrayList(new[]
                                                                                                       {40, 45, 33})
                                                                                     },
                                                                                 {
                                                                                     40,
                                                                                     new ArrayList(new[]
                                                                                                       {34, 46, 39})
                                                                                     },
                                                                                 {
                                                                                     41,
                                                                                     new ArrayList(new[]
                                                                                                       {-1, 47, 35})
                                                                                     },
                                                                                 {
                                                                                     42,
                                                                                     new ArrayList(new[]
                                                                                                       {43, -1, 36})
                                                                                     },
                                                                                 {
                                                                                     43,
                                                                                     new ArrayList(new[]
                                                                                                       {37, 48, 42})
                                                                                     },
                                                                                 {
                                                                                     44,
                                                                                     new ArrayList(new[]
                                                                                                       {45, 49, 38})
                                                                                     },
                                                                                 {
                                                                                     45,
                                                                                     new ArrayList(new[]
                                                                                                       {39, 50, 44})
                                                                                     },
                                                                                 {
                                                                                     46,
                                                                                     new ArrayList(new[]
                                                                                                       {47, 51, 40})
                                                                                     },
                                                                                 {
                                                                                     47,
                                                                                     new ArrayList(new[]
                                                                                                       {41, -1, 46})
                                                                                     },
                                                                                 {
                                                                                     48,
                                                                                     new ArrayList(new[]
                                                                                                       {49, -1, 43})
                                                                                     },
                                                                                 {
                                                                                     49,
                                                                                     new ArrayList(new[]
                                                                                                       {44, 52, 48})
                                                                                     },
                                                                                 {
                                                                                     50,
                                                                                     new ArrayList(new[]
                                                                                                       {51, 53, 45})
                                                                                     },
                                                                                 {
                                                                                     51,
                                                                                     new ArrayList(new[]
                                                                                                       {46, -1, 50})
                                                                                     },
                                                                                 {
                                                                                     52,
                                                                                     new ArrayList(new[]
                                                                                                       {53, -1, 49})
                                                                                     },
                                                                                 {
                                                                                     53,
                                                                                     new ArrayList(new[]
                                                                                                       {50, -1, 52})
                                                                                     },
                                                                             };

        #endregion

        #region TerrainTiles
        public ArrayList AllTerrainTiles =
            new ArrayList(new[]
                              {
                                  (int) TileType.Fields, (int) TileType.Pasture, (int) TileType.Hills,
                                  (int) TileType.Mountains, (int) TileType.Woods, (int) TileType.Fields,
                                  (int) TileType.Pasture, (int) TileType.Hills, (int) TileType.Mountains,
                                  (int) TileType.Woods, (int) TileType.Fields, (int) TileType.Pasture,
                                  (int) TileType.Hills
                                  , (int) TileType.Mountains, (int) TileType.Woods, (int) TileType.Fields,
                                  (int) TileType.Pasture, (int) TileType.Woods, (int) TileType.Desert
                              });

        #endregion

        public ArrayList AllPortTiles = new ArrayList(new[] { 0, 1, 2, 3, 4, 5, 5, 5, 5 });
        public ArrayList TerrainTiles { get; set; }
        public ArrayList PortTiles { get; set; }
        public ArrayList Vertices { get; set; }

        //The numbers for the tiles in spiral order
        private readonly ArrayList _tileNumberOrder =
            new ArrayList(new[] {5, 2, 6, 3, 8, 10, 9, 12, 11, 4, 8, 10, 9, 4, 5, 6, 3, 11});

        //The index of TerrainTiles to insert the tile
        private readonly ArrayList _tileOrder =
            new ArrayList(new[] {18, 17, 15, 10, 5, 2, 0, 1, 3, 8, 13, 16, 14, 12, 7, 4, 6, 11, 9});
        #endregion

        //Constructor for the Board class
        public Board()
        {
            TerrainTiles = new ArrayList(new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0});
            PortTiles = new ArrayList(new[] {0, 0, 0, 0, 0, 0, 0, 0, 0,});
            Vertices = new ArrayList();

            GenerateBoard();
        }

        //Generates a board for game play
        public void GenerateBoard()
        {
            //Generate the terrain tiles
            Shuffler.Shuffle(AllTerrainTiles);
            int tileCount = 0;
            int numCount = 0;
            int tempType;
            int tempNum;
            Tile tempTile;
            while (tileCount < 19)
            {
                tempType = (int) AllTerrainTiles[tileCount];
                tempNum = (int) _tileNumberOrder[numCount];
                if (tempType != (int) TileType.Desert)
                {
                    tempTile = new Tile(tempType, tempNum);
                    numCount++;
                }
                else
                {
                    tempTile = new Tile(tempType);
                }
                TerrainTiles[(int) (_tileOrder[tileCount])] = tempTile;
                tileCount++;
            }

            //Generate the port tiles
            Shuffler.Shuffle(AllPortTiles);
            tileCount = 0;
            while (tileCount < 9)
            {
                tempType = (int) AllPortTiles[tileCount];
                tempTile = new Tile(tempType);
                PortTiles[tileCount] = tempTile;
                tileCount++;
            }

            //Fill tile's neighbors
            int neighborCount = 0;
            int tempNeighbor;
            tileCount = 0;
            ArrayList tempNeighbors;
            while (tileCount < 19)
            {
                tempNeighbors = _neighborDictionary[tileCount];
                while (neighborCount < 6)
                {
                    tempNeighbor = (int) tempNeighbors[neighborCount];
                    if (tempNeighbor < 0)
                    {
                        tempNeighbors[neighborCount] = PortTiles[Math.Abs(tempNeighbor) - 1];
                    }
                    else if (tempNeighbor > 0)
                    {
                        tempNeighbors[neighborCount] = TerrainTiles[tempNeighbor - 1];
                    }
                    else
                    {
                        tempNeighbors[neighborCount] = new Tile((int) TileType.Sea);
                    }
                    neighborCount++;
                }
                tempTile = (Tile) TerrainTiles[tileCount];
                tempTile.Neighbors = tempNeighbors;
                TerrainTiles[tileCount] = tempTile;
                tileCount++;
            }

            //Generate the vertices
            for (int i = 0; i < 54; i++)
            {
                Vertices.Insert(i, new Vertex(i));
            }

            //Fill tile's vertices
            var category = new ArrayList(new[] {0, 2, 15, 17, 18});
            var offset1 = new ArrayList(new[] {3, 5, 6, 6, 5});
            var offset2 = new ArrayList(new[] {8, 11, 12, 11, 8});

            ArrayList tempList;
            int j;
            for (int i = 0; i < 19; i++)
            {
                j = 0;
                while ((int) category[j] < i)
                {
                    j++;
                }

                tempTile = (Tile) TerrainTiles[i];
                tempList = new ArrayList();
                tempList.Insert(0, Vertices[(2*i) + 1]);
                tempList.Insert(1, Vertices[(2*1) + (int) offset1[j] + 1]);
                tempList.Insert(2, Vertices[(2*1) + (int) offset2[j] + 1]);
                tempList.Insert(3, Vertices[(2*1) + (int) offset2[j]]);
                tempList.Insert(4, Vertices[(2*1) + (int) offset1[j]]);
                tempList.Insert(5, Vertices[(2*i)]);
                tempTile.Vertices = tempList;
                TerrainTiles[i] = tempTile;
            }

            //Fill Vertice's neighbors
            Vertex tempVertex;
            tempNeighbors = new ArrayList();
            for (int i = 0; i < 54; i++)
            {
                tempVertex = (Vertex) Vertices[i];
                tempNeighbors = _verticeDictionary[i];
                for (int k = 0; k < 3; k++)
                {
                    tempNum = (int) tempNeighbors[k];
                    if (tempNum > -1)
                    {
                        tempNeighbors[k] = Vertices[tempNum];
                    }
                    else
                    {
                        tempNeighbors[k] = null;
                    }
                }
                tempVertex.Neighbors = tempNeighbors;
                Vertices[i] = tempVertex;
            }
        }

        public void PlacePieceSetup(Settlement piece, int location)
        {
            Vertex targetVertex;
            // Check that vertex exists
            if (location < Vertices.Count && location >= 0)
            {
                // Get the vertex at the location specifed.
                targetVertex = (Vertex) Vertices[location];
            }
            else
            {
                throw new ArgumentException("This vertex doesn't exist.", "Bad Vertex");
            }
            //place the settlement at the vertex
            if (targetVertex.Settlement == null)
            {
                targetVertex.Settlement = piece;
            }
            else
            {
                throw new Exception("Settlement Already Exists Here");
            }
        }

        public void PlacePieceSetup(Road piece, int location, int direction)
        {
            PlacePiece(piece, location, direction);
        }

        public void PlacePiece(Settlement piece, int location)
        {
            Vertex targetVertex;
            // Check that vertex exists
            if (location < Vertices.Count && location >= 0)
            {
                // Get the vertex at the location specifed.
                targetVertex = (Vertex) Vertices[location];
            }
            else
            {
                throw new ArgumentException("This vertex doesn't exist.", "Bad Vertex");
            }
            if (targetVertex.PlayerCanBuildSettlement(piece.player))
            {
                //place the settlement at the vertex
                targetVertex.Settlement = piece;
            }
            else
            {
                throw new Exception(
                    "A settlement already exists at this vertex or the player doesn't have a road to this vertex");
            }
        }

        public void PlacePiece(Road piece, int location, int direction)
        {
            Vertex targetVertex;
            // Check that vertex exists
            if (location < Vertices.Count && location >= 0)
            {
                // Get the vertex at the location specifed.
                targetVertex = (Vertex) Vertices[location];
            }
            else
            {
                throw new ArgumentException("This vertex doesn't exist.", "Bad Vertex");
            }
            //Check direction valid
            if (direction < 0 || direction > 2)
            {
                throw new ArgumentException("This direction is invalid.", "Bad Direction");
            }
            // If this is a valid place to lay a road (has a neighboring node in this direction).
            if (targetVertex.PlayerCanBuildRoad(piece.player) && targetVertex.Neighbors[direction] != null)
            {
                //Place the road at the vertex in the specified direction
                targetVertex.Roads[direction] = piece;
                //Get the neighboring vertex
                var temp2 = (Vertex) targetVertex.Neighbors[direction];
                //get the index of the neighboring vertex
                int secondIndex = Vertices.IndexOf(temp2);

                int firstIndex = temp2.Neighbors.IndexOf(targetVertex);
                temp2.Roads[firstIndex] = piece;

                // use the difference between the vertices to determine which direction the road should go from the other vertex.
//                int difference = location - index;
//                if (difference > 1)
//                {
//                    // The neighbor node is in the preceding row
//                    temp2.Roads[1] = piece;
//                }
//                else
//                {
//                    //the neighbor node is in the same or next row
//                    if (location%2 == 0)
//                    {
//                        //and to the right of its neighbor node
//                        temp2.Roads[2] = piece;
//                    }
//                    else
//                    {
//                        //and to the left of its neighbor node
//                        temp2.Roads[0] = piece;
//                    }
//                }
            }
            else
            {
                throw new ArgumentException(
                    "This vertex has no neighbor vertex in the specified direction, all road spots at this vertex are taken, or player does not have a road touching this vertex.",
                    "Neighbor Vertex");
            }
        }
    }
}