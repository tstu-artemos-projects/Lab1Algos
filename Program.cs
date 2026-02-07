namespace Lab1Algos
{
	class MenuEntry
	{
		public required string Name;
		public required Action Action;
	}

	// Библеотека нужная везде
	class ParseLib
	{
		public static int ReadInt(string prompt)
		{
			while (true)
			{
				if (prompt != null)
					Console.Write(prompt + ": "); // вывод приглашения
				if (int.TryParse(Console.ReadLine(), out int result))
					return result;
				Console.WriteLine("Некорректный ввод. Пожалуйста, введите целое число.");
			}
		}
	}

	// Задачи
	class Actions
	{
		public static void Task1()
		{
			int totalSeconds = ParseLib.ReadInt("Введите время в секундах");
			if (totalSeconds < 0)
			{
				Console.WriteLine("Время не может быть отрицательным");
				return;
			}
			int minutes = totalSeconds / 60;
			int seconds = totalSeconds % 60;
			Console.WriteLine($"{totalSeconds} сек = {minutes} мин {seconds} сек");
		}

		public static void Task2()
		{
			int totalSeconds = ParseLib.ReadInt("Введите время в секундах");
			if (totalSeconds < 0)
			{
				Console.WriteLine("Время не может быть отрицательным");
				return;
			}
			int hours = totalSeconds / 3600;
			int minutes = (totalSeconds % 3600) / 60;
			int seconds = totalSeconds % 60;
			Console.WriteLine($"{totalSeconds} сек = {hours} ч {minutes} мин {seconds} сек");
		}

		public static void Task3()
		{
			int totalSeconds = ParseLib.ReadInt("Введите время в секундах");
			if (totalSeconds < 0)
			{
				Console.WriteLine("Время не может быть отрицательным");
				return;
			}
			double percentage = (totalSeconds / (24 * 60 * 60.0)) * 100;
			Console.WriteLine($"{totalSeconds} сек составляет {percentage:F2}% от суток");
		}
	}

	internal class Program
	{
		// Выводит меню из массива объектов MenuEntry
		static void WriteMenu(string name, MenuEntry[] entries)
		{
			do
			{
				Console.WriteLine("=== " + name + " ===");
				for (int i = 0; i < entries.Length; i++) // Выводим сами опции
				{
					Console.WriteLine($"{i + 1}. {entries[i].Name}");
				}
				int choice = ParseLib.ReadInt("Выберите действие");
				if (choice > entries.Length || choice < 0) // Если значения нет в меню
					Console.WriteLine("Нет такого значения в меню");
				else
					entries[choice - 1].Action(); // Исполняем функцию из меню
			} while (true);
		}

		static void Exit() // Завершение программы если поьзователь выбрал
		{
			Console.WriteLine("Завершение программы...");
			Environment.Exit(0);
		}


		static void Main(string[] args)
		{
			// Вывод меню с задачами, вставляя в Action метод с задачей
			WriteMenu("Перевод секунд в:", new[]
			{
				new MenuEntry
				{
						Name = "минуты и секунды",
						Action = Actions.Task1 // Задача первая
				},
				new MenuEntry
				{
						Name = "часы, минуты и секнуды",
						Action = Actions.Task2 // Задача вторая
				},
				new MenuEntry
				{
						Name = "проценты в дне",
						Action = Actions.Task3 // Задача третья
				},
				new MenuEntry
				{
						Name = "завершить программу",
						Action = Exit // Завершение работы программы
				}
			});
		}
	}
}
