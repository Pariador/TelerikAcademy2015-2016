#include <cstdio>
using namespace std;

static int maxFinal(int* changes, int numChanges, int beginLevel, int maxLevel)
{
	int n = numChanges;
	int** a = new int*[n + 1];
	for (int i = 0; i<n + 1; i++)
	{
		a[i] = new int[maxLevel + 1];
	}

	a[0][beginLevel] = 1;
	for (int i = 1; i <= n; i++)
	{
		for (int j = 0; j <= maxLevel; j++)
		{
			if (a[i - 1][j] == 1)
			{
				int x = changes[i - 1];
				if (j - x >= 0)
				{
					a[i][j - x] = 1;
				}
				if (j + x <= maxLevel)
				{
					a[i][j + x] = 1;
				}
			}
		}
	}

	for (int i = maxLevel; i >= 0; i--)
	{
		if (a[n][i] == 1)
		{
			return i;
		}
	}
	return -1;
}


int main()
{
	int numChanges;
	scanf("%d", &numChanges);

	int* changes = new int[numChanges];

	for (int i = 0; i<numChanges; i++)
	{
		scanf("%d", &changes[i]);
	}

	int beginLevel, maxLevel;
	scanf("%d", &beginLevel);
	scanf("%d", &maxLevel);

	int answer = maxFinal(changes, numChanges, beginLevel, maxLevel);

	printf("%d", answer);

	return 0;
}

