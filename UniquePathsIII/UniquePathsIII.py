from typing import List, Tuple

class GridMetadata():
    def __init__(self, m: int, n: int, startIndex: Tuple[int], endIndex: Tuple[int], numObstacles: int):
        self.m = m
        self.n = n
        self.startIndex = startIndex
        self.endIndex = endIndex
        self.numTraversableSquares = m * n - numObstacles

class Solution:
    START_SQUARE = 1
    END_SQUARE = 2
    EMPTY_SQUARE = 0
    OBSTACLE_SQUARE = -1
    
    def parseGrid(grid: List[List[int]]) -> GridMetadata:
        m = len(grid)
        n = len(grid[0])

        startSquareIndex = (-1, -1)
        endSquareIndex = (-1, -1)
        
        numObstacles = 0
        
        for i in range(0, m):
            for j in range(0, n):
                if grid[i][j] == Solution.START_SQUARE:
                    startSquareIndex = (i, j)
                elif grid[i][j] == Solution.END_SQUARE:
                    endSquareIndex = (i, j)
                elif grid[i][j] == Solution.OBSTACLE_SQUARE:
                    numObstacles += 1;

        return GridMetadata(m, n, startSquareIndex, endSquareIndex, numObstacles)
            
    def canVisit(self, grid: List[List[int]], visited: List[List[bool]], i: int, j: int, gridMetadata: GridMetadata) -> bool:
        return i >= 0 and i < gridMetadata.m and j >= 0 and j < gridMetadata.n and grid[i][j] != Solution.OBSTACLE_SQUARE and not visited[i][j]
    
    
    def visit(self, grid: List[List[int]], visited: List[List[bool]], i: int, j: int, numTraversed: int, gridMetadata: GridMetadata) -> int:
        visited[i][j] = True
        numPaths = self.traverseGrid(grid, visited, i, j, numTraversed + 1, gridMetadata)
        visited[i][j] = False
        return numPaths
        
            
    def traverseGrid(self, grid: List[List[int]], visited: List[List[bool]], i: int, j: int, numTraversed: int, gridMetadata: GridMetadata):
        if (i == gridMetadata.endIndex[0] and j == gridMetadata.endIndex[1] and numTraversed == gridMetadata.numTraversableSquares):
            return 1
        
        numPaths = 0
        
        if (self.canVisit(grid, visited, i - 1, j, gridMetadata)):
            numPaths += self.visit(grid, visited, i - 1, j, numTraversed, gridMetadata)
            
        if (self.canVisit(grid, visited, i, j - 1, gridMetadata)):
            numPaths += self.visit(grid, visited, i, j - 1, numTraversed, gridMetadata)
            
        if (self.canVisit(grid, visited, i + 1, j, gridMetadata)):
            numPaths += self.visit(grid, visited, i + 1, j, numTraversed, gridMetadata)
            
        if (self.canVisit(grid, visited, i, j + 1, gridMetadata)):
            numPaths += self.visit(grid, visited, i, j + 1, numTraversed, gridMetadata)
        
        return numPaths
        
        
    def uniquePathsIII(self, grid: List[List[int]]) -> int:
        
        gridMetadata = Solution.parseGrid(grid)
        
        visited = [[False for y in range(gridMetadata.n)] for x in range(gridMetadata.m)]        
        visited[gridMetadata.startIndex[0]][gridMetadata.startIndex[1]] = True
        
        return self.traverseGrid(grid, visited, gridMetadata.startIndex[0], gridMetadata.startIndex[1], 1, gridMetadata)

obstacleGrid = [[1,0,0,0],[0,0,0,0],[0,0,2,-1]]

solution = Solution()
print(solution.uniquePathsIII(obstacleGrid))