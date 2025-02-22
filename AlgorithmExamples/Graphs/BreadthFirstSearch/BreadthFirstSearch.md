# Breadth First Search

## Pseudo Code
```
//Where G is the graph and s is the source node
BFS (G, s)                   
    let Q be queue.
    //Inserting s in queue until all its neighbour vertices are marked.
    Q.enqueue( s ) 

    mark s as visited.
    while ( Q is not empty)
        //Removing that vertex from queue,whose neighbour will be visited now
        v  =  Q.dequeue( )
        
        //processing all the neighbours of v  
        for all neighbours w of v in Graph G
            if w is not visited 
                //Stores w in Q to further visit its neighbour
                Q.enqueue( w )             
                mark w as visited.
```

### Resources
- https://www.cs.usfca.edu/~galles/visualization/BFS.html
- https://github.com/trekhleb/javascript-algorithms/tree/master/src/algorithms/graph/breadth-first-search
- https://www.hackerearth.com/practice/algorithms/graphs/breadth-first-search/tutorial/

