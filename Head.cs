global using System;
global using System.Diagnostics;
static partial class Program
{
    enum Cell
    {
        Empty,
        Digit1,
        Digit2,
        Digit3,
        Digit4,
        Digit5,
        Digit6,
        Digit7,
        Digit8,
        Digit9,
        Crate,
        Star,
        Projectile,
        Cannon,
        UltraProjectile,
        Attach,
    }

    private const int UltraBombRadius = 10;
    static Cell[,] _field;
    static int _cannonX;
    static int _cannonY;

    static int _prevCannonX;
    static int _prevCannonY;
    static long _slowTimeEndTime;
    static long _fireEndTime;
    static long _ultraCannonEndTime;
    static bool _cannonFired;
    static bool _bombFired;
    static bool _ultraBombFired;
    static bool _slowTimeActivated;
    static bool _fireActivated;
    static bool _ultraCannonActivated;
    static bool _isCommand;
    static string _command;
    static long _projectileTime;
    static long _digitGenTime;
    static long _digitMoveTime;
    static long _bombTime;
    static long _ultraBombTime;
    static bool _gameOver;
    static bool _hasBomb;
    static bool _hasUltraBomb;
    static int _slowTimeCount;
    static int _fireCount;
    static int _ultraCannonCount;
    static int _fastProjectileCount;
    static int _fastProjectileTime;
    static bool _fastProjectileActivated;
    static readonly Random _rng = new();
    static int _score;
    static long _currentTime;
    static int _energy;
    private static int _attachLife = 10;

    static void Main(string[] args)
    {
        try
        {
            Console.CursorVisible = false;
            _slowTimeCount = _fireCount = _ultraCannonCount = 1;
            _score = -40;
            _field = new Cell[5, 36];
            _cannonY = _field.GetLength(1) - 1;
            Console.CursorVisible = false;
            _attachTime = _currentTime;
            AddAttach(0, 0, 0, 0, Cell.Digit9);
            while (!_gameOver)
            {
                ProcessInput();
                ProcessLogic(0.1);
                DrawField();
            }
            Console.ReadKey();
        }
        catch (System.Exception exception)
        {
            Console.Error.WriteLine(exception);
        }
    }
}