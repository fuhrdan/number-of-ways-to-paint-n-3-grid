//*****************************************************************************
//** 1411. Number of Ways to Paint N × 3 Grid                       leetcode **
//*****************************************************************************
//** Humble Optimists Persist Endlessly,                                     **
//** Through bugs that lurk and nights that bend,                            **
//** Each failure teaches, not condemns,                                     **
//** Till patient code and purpose blend.                                    **
//*****************************************************************************

#define MOD 1000000007

static int temp1[3];
static int temp2[3];

bool selfOK(int p)
{
    for (int i = 0; i < 3; i++)
    {
        temp1[i] = p % 3;
        p /= 3;
    }

    return (temp1[0] != temp1[1] &&
            temp1[1] != temp1[2]);
}

bool crossOK(int p, int q)
{
    for (int i = 0; i < 3; i++)
    {
        temp1[i] = p % 3;
        temp2[i] = q % 3;
        p /= 3;
        q /= 3;
    }

    return (temp1[0] != temp2[0] &&
            temp1[1] != temp2[1] &&
            temp1[2] != temp2[2]);
}

int numOfWays(int n)
{
    int dp[27] = {0};
    int dp_prev[27];
    int retval = 0;

    for (int p = 0; p < 27; p++)
    {
        if (selfOK(p))
            dp[p] = 1;
    }

    for (int i = 1; i < n; i++)
    {
        for (int p = 0; p < 27; p++)
            dp_prev[p] = dp[p];

        for (int p = 0; p < 27; p++)
        {
            dp[p] = 0;
            if (!selfOK(p)) continue;

            for (int q = 0; q < 27; q++)
            {
                if (!selfOK(q)) continue;
                if (crossOK(p, q))
                {
                    dp[p] = (dp[p] + dp_prev[q]) % MOD;
                }
            }
        }
    }

    for (int p = 0; p < 27; p++)
    {
        if (selfOK(p))
            retval = (retval + dp[p]) % MOD;
    }

    return retval;
}
