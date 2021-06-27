from typing import List

class Solution:
    def uniquePathsWithObstacles(self, obstacleGrid: List[List[int]]) -> int:
        if obstacleGrid[0][0] == 1: 
            return 0
        
        m = len(obstacleGrid)
        n = len(obstacleGrid[0])
        
        uniquePathsToPoint = [[0 for x in range(n)] for y in range(m)]
        
        for i in range(m):
            for j in range(n):
                if i == 0 and j == 0:
                    uniquePathsToPoint[i][j] = 1
                elif i == 0:
                    if obstacleGrid[i][j] == 0:
                        uniquePathsToPoint[i][j] = uniquePathsToPoint[i][j - 1]
                elif j == 0:
                    if obstacleGrid[i][j] == 0:
                        uniquePathsToPoint[i][j] = uniquePathsToPoint[i - 1][j]
                elif obstacleGrid[i][j] == 0:
                    uniquePathsToPoint[i][j] = uniquePathsToPoint[i - 1][j] + uniquePathsToPoint[i][j - 1]
        
        return uniquePathsToPoint[m - 1][n - 1]


obstacleGrid = [
    [0,0,0],
    [0,1,0],
    [0,0,0]
]

solution = Solution()
print(solution.uniquePathsWithObstacles(obstacleGrid))

