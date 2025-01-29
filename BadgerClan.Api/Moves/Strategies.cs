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
    public static void Turtle(MoveRequest request, List<Move> moves)
    {

        var enemies = request.Units.Where(u => u.Team != request.YourTeamId);
        var squad = request.Units.Where(u => u.Team == request.YourTeamId);

        if (!squad.Any() || !enemies.Any()) return;

        var avgX = (int)squad.Average(u => u.Location.Row);
        var avgY = (int)squad.Average(u => u.Location.Col);
        var gatheringPoint = new Coordinate(avgX, avgY);

        foreach (var unit in squad)
        {
            var closestEnemy = enemies.OrderBy(u => u.Location.Distance(unit.Location)).FirstOrDefault();
            if (closestEnemy != null)
            {
                var awayFromEnemy = unit.Location.Away(closestEnemy.Location);

                var towardGathering = unit.Location.Toward(gatheringPoint);

                if (awayFromEnemy.Distance(closestEnemy.Location) > towardGathering.Distance(closestEnemy.Location))
                {
                    moves.Add(new Move(MoveType.Walk, unit.Id, awayFromEnemy));
                }
                else
                {
                    moves.Add(new Move(MoveType.Walk, unit.Id, towardGathering));
                }
            }
        }
    }
}
