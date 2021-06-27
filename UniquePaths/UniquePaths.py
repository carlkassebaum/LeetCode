class Solution:
    def uniquePaths(self, m: int, n: int) -> int:
        uniquePathsToPoint = Matrix = [[0 for x in range(n)] for y in range(m)]
        
        for i in range(m):
            for j in range(n):
                if i == 0 or j == 0:
                    uniquePathsToPoint[i][j] = 1
                else:
                    uniquePathsToPoint[i][j] = uniquePathsToPoint[i - 1][j] + uniquePathsToPoint[i][j - 1]
        
        return uniquePathsToPoint[m - 1][n - 1]

m = 3
n = 3

solution = Solution()
print(solution.uniquePaths(m, n))
