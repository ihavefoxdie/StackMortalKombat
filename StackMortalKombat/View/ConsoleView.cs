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

    protected override void BattleMenu()
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
        int tempValue = 0;
        List<AbstractUnit> army1 = new List<AbstractUnit>();
        List<AbstractUnit> army2 = new List<AbstractUnit>();
        IStrategy strategy;
        Func<AbstractUnitFactory, string> UnitName = unit => unit.Name;

        PrintIntro();

        tempValue = (int)AnsiConsole.Ask<uint>("Enter Army [underline yellow]Value[/]:");
        army1 = FillArmy(1, tempValue);
        army2 = FillArmy(2, tempValue);
        strategy = ChooseStrategy();
        _battleHistory._battleContext.army1 = army1;
        _battleHistory._battleContext.army2 = army2;
        _battleHistory._battleContext.Strategy = strategy;



        List<AbstractUnit> FillArmy(int armyNumber, int value)
        {
            List<AbstractUnit> list = new List<AbstractUnit>();


            while (value >= 4)
            {
                AnsiConsole.Clear();
                AnsiConsole.Write(new FigletText($"Army #{armyNumber}")
                            .Justify(Justify.Center)
                            .Color(Color.Orange1));
                Thread.Sleep(100);
                AnsiConsole.Markup($"Value : [underline orange1]{value}[/]\n");
                ChooseUnit();

            }
            Console.Clear();
            PrintIntro();
            return list;

            void ChooseUnit()
            {
                AbstractUnitFactory factory;
                int unitValue;


                string unitToAdd = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("\nUnits To Add:").HighlightStyle(Color.Purple_1)
                    .PageSize(10).AddChoices(new[] {
                    "Infantry",
                    "Heavy Infantry",
                    "Knight",
                    "WalkTheCity",
                    "Special Infantry",
                    "Archer",
                    "Healer",
                    "Witcher",
                    }));


                switch (unitToAdd)
                {
                    case "Infantry":
                        factory = new InfantryFactory();
                        unitValue = factory.GetCost();
                        if (value - unitValue >= 0)
                        {
                            list.Add(factory.CreateUnit());
                            value -= unitValue;
                        }
                        else
                        {
                            AnsiConsole.Console.Markup($"[red]You can't afford it[/] {value} - {unitValue}");
                            Thread.Sleep(100);
                            ChooseUnit();
                        }
                        break;

                    case "Special Infantry":
                        factory = new SpecialInfantryFactory();
                        unitValue = factory.GetCost();
                        if (value - unitValue >= 0)
                        {
                            list.Add(factory.CreateUnit());
                            value -= unitValue;
                        }
                        else
                        {
                            AnsiConsole.Console.Markup($"[red]You can't afford it[/] {value} - {unitValue}");
                            Thread.Sleep(100);
                            ChooseUnit();
                        }
                        break;

                    case "Heavy Infantry":
                        factory = new HeavyInfantryFactory();
                        unitValue = factory.GetCost();
                        if (value - unitValue >= 0)
                        {
                            list.Add(factory.CreateUnit());
                            value -= unitValue;
                        }
                        else
                        {
                            AnsiConsole.Console.Markup($"[red]You can't afford it[/] {value} - {unitValue}\n");
                            Thread.Sleep(100);
                            ChooseUnit();
                        }
                        break;

                    case "Knight":
                        factory = new KnightFactory();
                        unitValue = factory.GetCost();
                        if (value - unitValue >= 0)
                        {
                            list.Add(factory.CreateUnit());
                            value -= unitValue;
                        }
                        else
                        {
                            AnsiConsole.Console.Markup($"[red]You can't afford it[/] {value} - {unitValue}\n");
                            Thread.Sleep(100);
                            ChooseUnit();
                        }
                        break;

                    case "WalkTheCity":
                        factory = new WalkTheCityFactory();
                        unitValue = factory.GetCost();
                        if (value - unitValue >= 0)
                        {
                            list.Add(factory.CreateUnit());
                            value -= unitValue;
                        }
                        else
                        {
                            AnsiConsole.Console.Markup($"[red]You can't afford it[/] {value} - {unitValue}\n");
                            Thread.Sleep(100);
                            ChooseUnit();
                        }
                        break;

                    case "Archer":
                        factory = new ArcherFactory(chooseUsualUnit());
                        unitValue = factory.GetCost();
                        if (value - unitValue >= 0)
                        {
                            list.Add(factory.CreateUnit());
                            value -= unitValue;
                        }
                        else
                        {
                            AnsiConsole.Console.Markup($"[red]You can't afford it[/] {value} - {unitValue}\n");
                            Thread.Sleep(100);
                            ChooseUnit();
                        }
                        break;

                    case "Healer":
                        factory = new HealerFactory(chooseUsualUnit());
                        unitValue = factory.GetCost();
                        if (value - unitValue >= 0)
                        {
                            list.Add(factory.CreateUnit());
                            value -= unitValue;
                        }
                        else
                        {
                            AnsiConsole.Console.Markup($"[red]You can't afford it[/] {value} - {unitValue}\n");
                            Thread.Sleep(100);
                            ChooseUnit();
                        }
                        break;

                    case "Witcher":
                        factory = new WitcherFactory(chooseUsualUnit());
                        unitValue = factory.GetCost();
                        if (value - unitValue >= 0)
                        {
                            list.Add(factory.CreateUnit());
                            value -= unitValue;
                        }
                        else
                        {
                            AnsiConsole.Console.Markup($"[red]You can't afford it[/] {value} - {unitValue}\n");
                            Thread.Sleep(100);
                            ChooseUnit();
                        }
                        break;
                    default:
                        break;
                }

                AbstractUnit chooseUsualUnit()
                {

                    AbstractUnitFactory usualFactory = new InfantryFactory();
                    AnsiConsole.WriteLine();
                    string usualUnitToAdd = AnsiConsole.Prompt(new SelectionPrompt<string>()
                    .Title("Units To Add:").HighlightStyle(Color.Purple_1)
                    .PageSize(10).AddChoices(new[] {

                    "Infantry",
                    "Heavy Infantry",
                    "Knight",

                    }));

                    switch (usualUnitToAdd)
                    {

                        case "Infantry":
                            usualFactory = new InfantryFactory();
                            break;

                        case "Heavy Infantry":
                            usualFactory = new HeavyInfantryFactory();
                            break;

                        case "Knight":
                            usualFactory = new KnightFactory();
                            break;


                        default:
                            break;
                    }

                    return usualFactory.CreateUnit();
                }

            }
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

    public void PrintBattleInfo()
    {
        Func<IStrategy, string> StrategyName = strategy => strategy.GetType().Name;

        PrintArmy(_battleHistory._battleContext.army1);
        AnsiConsole.Write(" ||| ");
        PrintArmy(_battleHistory._battleContext.army2, true);
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();

        AnsiConsole.Markup($"Strategy : [underline Aquamarine1_1]{StrategyName(_battleHistory._battleContext.Strategy)}[/]");
    }

    public override void PrintFinishBattleInfo()
    {
        Func<IStrategy, string> StrategyName = strategy => strategy.GetType().Name;
        AnsiConsole.WriteLine();
        PrintArmy(_battleHistory._battleContext.army1);
        AnsiConsole.Write(" ||| ");
        PrintArmy(_battleHistory._battleContext.army2, true);
        AnsiConsole.WriteLine();
        AnsiConsole.WriteLine();

    }

    private void PrintArmy(List<AbstractUnit> list, bool reverse = false)
    {
        AnsiConsole.Write("[");
        if (reverse)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                AnsiConsole.Markup((list[i].Name + ":" + "[red]" + list[i].Health + "[/] "));
            }
        }

        else
        {
            for (int i = 0; i < list.Count; i++)
            {
                AnsiConsole.Markup((list[i].Name + ":" + "[red]" + list[i].Health + "[/] "));
            }
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