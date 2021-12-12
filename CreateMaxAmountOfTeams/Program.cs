

var skill = new List<int> { 3, 4, 3, 1, 6, 5 };
int teamSize = 3;
int maxDiff = 2;
// result = 2
Console.WriteLine(countMaximumTeams(skill, teamSize, maxDiff));

skill = new List<int> { 9, 3, 5, 7, 1 };
teamSize = 2;
maxDiff = 1;
// result 0
Console.WriteLine(countMaximumTeams(skill, teamSize, maxDiff));

skill = new List<int> { 3, 4, 3, 1, 6 };
teamSize = 3;
maxDiff = 2;
// result = 1
Console.WriteLine(countMaximumTeams(skill, teamSize, maxDiff));

Console.WriteLine("press any key..");
Console.ReadKey();

    static int countMaximumTeams(List<int> skill, int teamSize, int maxDiff)
    {
        skill.Sort();

        int i = 0;
        int j = teamSize - 1;
        int count = 0;

        while (j < skill.Count)
        {
            if (skill[j] - skill[i] <= maxDiff)
            {
                count++;
                i = j + 1;
                j = i + 2;
            }
            else
            {
                i++;
                j++;
            }
        }

        return count;
    }

static int countMaximumTeams2(List<int> skill, int teamSize, int maxDiff)
{
    skill.Sort();
    skill.Reverse();

    int maxTeamCount = 0;

    for (int k = 0; k < skill.Count; k++)
    {
        if (skill.Count < teamSize)
            break;

        int t0 = 0;  // first in new team
        int tCount = 0;


        for (int j = 0; j < teamSize; j++)
        {
            if (tCount >= teamSize)
                break;

            for (int i = skill.Count; i-- > 0;)
            {
                if (tCount == 0)
                {
                    t0 = skill[i];
                    tCount++;
                    skill.RemoveAt(i);
                }
                else
                {
                    if (tCount >= teamSize)
                        break;

                    bool isSkillInRange = skill[i] - t0 <= maxDiff;
                    if (isSkillInRange)
                    {
                        tCount++;
                        skill.RemoveAt(i);
                        if (tCount >= teamSize)
                        {
                            maxTeamCount++;
                            break;
                        }
                    }
                }
            }
        }

    }

    return maxTeamCount;
}

static int countMaximumTeamsSlow(List<int> skill, int teamSize, int maxDiff)
{
    skill.Sort();
    skill.Reverse();

    int maxTeamCount = 0;

    for (int k = 0; k < skill.Count; k++)
    {
        var t = new List<int>(); // new team
        for (int j = 0; j < teamSize; j++)
        {
            for (int i = skill.Count; i-- > 0;)
            {
                if (t.Count == 0)
                {
                    t.Add(skill[i]);
                    skill.RemoveAt(i);
                }
                else
                {
                    if (t.Count >= teamSize)
                        break;

                    bool isSkillInRange = skill[i] - t[0] <= maxDiff;
                    if (isSkillInRange)
                    {
                        t.Add(skill[i]);
                        skill.RemoveAt(i);
                        if (t.Count >= teamSize)
                        {
                            if (t.Count == teamSize)
                                maxTeamCount++;
                            else
                                break;
                        }
                    }
                }
            }
        }

    }

    return maxTeamCount;
}