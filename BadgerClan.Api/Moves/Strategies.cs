using BadgerClan.Logic;
using BadgerClan.Logic.Bot;
using System.Reflection.Emit;

namespace BadgerClan.Api.Moves;

public static class Strategies
{
    public static string Strategy = "";
    public static void RunAndGun(MoveRequest request, List<Move> moves)
    {
        foreach (var unit in request.Units.Where(u => u.Team == request.YourTeamId))
        {

            var enemies = request.Units.Where(u => u.Team != request.YourTeamId);
            var closest = enemies.OrderBy(u => u.Location.Distance(unit.Location)).FirstOrDefault();
            if (closest != null)
            {

                if (closest.Location.Distance(unit.Location) <= unit.AttackDistance)
                {
                    
                    moves.Add(Moves.AttackClosest(unit, closest));
                    moves.Add(Moves.AttackClosest(unit, closest));
                }
                else
                {
                    moves.Add(Moves.StepToClosest(unit, closest, request.Units));
                }
            }

        }
    }
    public static void RunAway(MoveRequest request, List<Move> moves)
    {
        var enemies = request.Units.Where(u => u.Team != request.YourTeamId);
        var squad = request.Units.Where(u => u.Team == request.YourTeamId);
        
        foreach (var unit in squad)
        {
            var closestEnemy = enemies.OrderBy(u => u.Location.Distance(unit.Location)).FirstOrDefault();
            if (closestEnemy != null)
            {
                var awayFromEnemy = unit.Location.Away(closestEnemy.Location);

                moves.Add(Moves.MoveAway(unit, awayFromEnemy));
            }
        }
    }
}
