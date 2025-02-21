# Depth First Search

## Pseudo Code
```
//Where G is graph and s is source vertex
DFS-iterative (G, s):                                   
      let S be stack
      S.push( s )            //Inserting s in stack 
      mark s as visited.
      while ( S is not empty):
          //Pop a vertex from stack to visit next
          v  =  S.top( )
          S.pop( )
          //Push all the neighbours of v in stack that are not visited   
          for all neighbours w of v in Graph G:
          if w is not visited :
             S.push( w )         
             mark w as visited

OR

DFS-recursive(G, s):
    mark s as visited
    for all neighbours w of s in Graph G:
        if w is not visited:
            DFS-recursive(G, w)
```

### Resources
- https://www.cs.usfca.edu/~galles/visualization/DFS.html
- https://www.hackerearth.com/practice/algorithms/graphs/depth-first-search/tutorial/
