using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SettlersOfCatan
{
    public class Board
    {
        public ArrayList tiles { get; set; }
        public ArrayList vertices { get; set; }

        //All tiles know their neighbors and all vertices know neighbors
        public Board()
        {
            tiles = new ArrayList(21);
            vertices = new ArrayList();

            this.GenerateBoard();
        }

        public void GenerateBoard()
        {

        }

        public void placeFirstPiece(Settlement piece, int location)
        {
            Vertex targetVertex;
            // Check that vertex exists
            if (location < vertices.Count && location >= 0)
            {
                // Get the vertex at the location specifed.
                targetVertex = (Vertex)vertices[location];
            }
            else
            {
                throw new System.ArgumentException("This vertex doesn't exist.", "Bad Vertex");
            }
            //place the settlement at the vertex
            targetVertex.settlement = piece;
        }

        public void placeFirstPiece(Road piece, int location, int direction)
        {
            Vertex targetVertex;
            // Check that vertex exists
            if (location < vertices.Count && location >= 0)
            {
                // Get the vertex at the location specifed.
                targetVertex = (Vertex)vertices[location];
            }
            else
            {
                throw new System.ArgumentException("This vertex doesn't exist.", "Bad Vertex");
            }
            // If this is a valid place to lay a road (has a neighboring node in this direction).
            if (targetVertex.neighbors[direction] != null)
            {
                //Place the road at the vertex in the specified direction
                targetVertex.roads[direction] = piece;
                //Get the neighboring vertex
                Vertex temp2 = (Vertex)targetVertex.neighbors[direction];
                //get the index of the neighboring vertex
                int index = vertices.IndexOf(temp2);
                // use the difference between the vertices to determine which direction the road should go from the other vertex.
                int difference = location - index;
                if (difference > 1)
                {
                    // The neighbor node is in the preceding row
                    temp2.roads[1] = piece;
                }
                else
                {
                    //the neighbor node is in the same or next row
                    if (location % 2 == 0)
                    {
                        //and to the right of its neighbor node
                        temp2.roads[2] = piece;
                    }
                    else
                    {
                        //and to the left of its neighbor node
                        temp2.roads[0] = piece;
                    }
                }
            }
            else
            {
                throw new System.ArgumentException("This vertex has no neighbor vertex in the specified direction.", "Neighbor Vertex");
            }
        }

        public void placePiece(Settlement piece, int location)
        {
            Vertex targetVertex;
            // Check that vertex exists
            if (location < vertices.Count && location >= 0)
            {
                // Get the vertex at the location specifed.
                targetVertex = (Vertex)vertices[location];
            }
            else
            {
                throw new System.ArgumentException("This vertex doesn't exist.", "Bad Vertex");
            }
            if (targetVertex.playerCanBuildSettlement(piece.player))
            {
                //place the settlement at the vertex
                targetVertex.settlement = piece;
            }
            else
            {
                throw new System.Exception("A settlement already exists at this vertex or the player doesn't have a road to this vertex");
            }
        }

        public void placePiece(Road piece, int location, int direction)
        {
            Vertex targetVertex;
            // Check that vertex exists
            if (location < vertices.Count && location >= 0)
            {
                // Get the vertex at the location specifed.
                targetVertex = (Vertex)vertices[location];
            }
            else
            {
                throw new System.ArgumentException("This vertex doesn't exist.", "Bad Vertex");
            }
            // If this is a valid place to lay a road (has a neighboring node in this direction).
            if (targetVertex.playerCanBuildSettlement(piece.player) && targetVertex.neighbors[direction] != null)
            {
                //Place the road at the vertex in the specified direction
                targetVertex.roads[direction] = piece;
                //Get the neighboring vertex
                Vertex temp2 = (Vertex)targetVertex.neighbors[direction];
                //get the index of the neighboring vertex
                int index = vertices.IndexOf(temp2);
                // use the difference between the vertices to determine which direction the road should go from the other vertex.
                int difference = location - index;
                if (difference > 1)
                {
                    // The neighbor node is in the preceding row
                    temp2.roads[1] = piece;
                }
                else
                {
                    //the neighbor node is in the same or next row
                    if (location % 2 == 0)
                    {
                        //and to the right of its neighbor node
                        temp2.roads[2] = piece;
                    }
                    else
                    {
                        //and to the left of its neighbor node
                        temp2.roads[0] = piece;
                    }
                }
            }
            else
            {
                throw new System.ArgumentException("This vertex has no neighbor vertex in the specified direction, all road spots at this vertex are taken, or player does not have a road touching this vertex.", "Neighbor Vertex");
            }
        }
    }
}
