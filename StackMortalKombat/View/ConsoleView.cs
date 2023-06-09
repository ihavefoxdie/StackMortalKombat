using Spectre.Console;
using StackMortalKombat.Commands;
using StackMortalKombat.Factories;
using StackMortalKombat.Interfaces;
using StackMortalKombat.Strategies;
using StackMortalKombat.Units;
using System.Diagnostics;

namespace StackMortalKombat.View;

internal class ConsoleView : AbstractView
{
    public ConsoleView(BattleHistory battleHistory) : base(battleHistory)
    {

    }

    public override void BattleMenu()
    {
        AnsiConsole.Clear();
        PrintBattleInfo();
        AnsiConsole.WriteLine("\n\n");

        string command = AnsiConsole.Prompt(new SelectionPrompt<string>()
        .Title("Possibilities:").HighlightStyle(Color.Purple_1)
        .PageSize(10)
        .AddChoices(new[] {
            "Undo",
            "Redo",
            "ChangeStrategy",
            "NextTurn",
            "Finish"
        }));



        switch (command)
        {
            case "Undo":
                _battleHistory.Undo();
                break;

            case "Redo":
                _battleHistory.Redo();
                break;

            case "ChangeStrategy":
                
                _battleHistory.SetCommand(new ChangeStrategyCommand(_battleHistory._battleContext, ChooseStrategy()));
                _battleHistory.Execute();
                break;

            case "NextTurn":
                _battleHistory.SetCommand(new NextTurnCommand(_battleHistory._battleContext));
                _battleHistory.Execute();
                break;

            case "Finish":
                _battleHistory.SetCommand(new ToFinishCommand(_battleHistory._battleContext, _battleHistory));
                _battleHistory.Execute();
                break;

            default:
                Debug.Write("Unfamiliar Command");
                break;
        }



    }

    public override void StartMenu()
    {
        uint tempValue = 0;
        List<AbstractUnit> army1 = new List<AbstractUnit>();
        List<AbstractUnit> army2 = new List<AbstractUnit>();
        IStrategy strategy;
        Func<AbstractUnitFactory, string> UnitName = unit => unit.Name;

        PrintIntro();

        tempValue = AnsiConsole.Ask<uint>("Enter Army [underline yellow]Value[/]:");
        army1 = FillArmy(1, tempValue);
        army2 = FillArmy(2, tempValue);
        strategy = ChooseStrategy();
        _battleHistory._battleContext.army1 = army1;
        _battleHistory._battleContext.army2 = army2;
        _battleHistory._battleContext.Strategy = strategy;




        List<AbstractUnit> FillArmy(int armyNumber, uint value)
        {

            List<AbstractUnit> list = new List<AbstractUnit>();

            AnsiConsole.Write(new FigletText($"Army #{armyNumber}")
                .Justify(Justify.Center)
                .Color(Color.Orange1));

            while (value > 0)
            {
                var newFactory = AnsiConsole.Prompt(new SelectionPrompt<AbstractUnitFactory>()
                .PageSize(3)
                .AddChoices(new AbstractUnitFactory[] { new InfantryFactory(), new HeavyInfantryFactory(), new KnightFactory() })
                .UseConverter(UnitName)
                );

                list.Add(newFactory.CreateUnit());
                Thread.Sleep(100);

                //TODO Value is static!!!
                value -= 5;
            }
            return list;
        }
    }

    private IStrategy ChooseStrategy()
    {
        Func<IStrategy, string> StrategyName = strategy => strategy.GetType().Name;

        return AnsiConsole.Prompt(new SelectionPrompt<IStrategy>()
        .PageSize(3)
        .AddChoices(new IStrategy[] { new StrategyHorizontally(), new StrategyRows(), new StrategyVertically() })
        .UseConverter(StrategyName)
        );

    }

    private void PrintBattleInfo()
    {
        Func<IStrategy, string> StrategyName = strategy => strategy.GetType().Name;

        PrintArmy(_battleHistory._battleContext.army1);
        AnsiConsole.Write(" ||| ");
        PrintArmy(_battleHistory._battleContext.army2);
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();

        AnsiConsole.MarkupLine($"Strategy : [underline Aquamarine1_1]{StrategyName(_battleHistory._battleContext.Strategy)}[/]");
    }

    private void PrintArmy(List<AbstractUnit> list)
    {
        AnsiConsole.Write("[");
        foreach (var item in list)
        {
            AnsiConsole.Markup((item.Name + ":" + "[red]" + item.Health + "[/] "));
        }
        AnsiConsole.Write("]");
    }

    private void PrintIntro()
    {
        AnsiConsole.Write(new FigletText("MortalKombat")
            .Centered()
            .Color(Color.SandyBrown))
            ;
    }

    protected override void StrategyMenu()
    {
        throw new NotImplementedException();
    }


}