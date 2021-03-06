# iTransition-homework-rock-paper-scissors
На языке со статической типизацией (на выбор Java или C#) реализовать скрипт (в виде jar-файла или исполняемой сборки), который реализует обобщенную игру камень-ножницы-бумага (любое число произвольных комбинаций).

При запуске параметрами командной строки (аргументы метода main или Main) передаётся нечётное число >=3 неповторяющихся строк (при неправильно заданных аргументах вывести аккуратное сообщение об ошибке — что неверно, пример как правильно). Эти строки — это ходы (например, Камень Ножницы Бумага или Камень Ножницы Бумага Ящерица Спок или 1 2 3 4 5 6 7 8 9).

Победа определяется так — половина следующих по кругу выигрывает, половина предыдущих по кругу проигрывает (семантика строк не важна, в какой последовательности что пользователь ввел, в том и играет).

Скрипт генерирует случайный ключ (SecureRandom или RandomNumberGenerator — обязательно!) длиной 128 бит, делает свой ход (опять же безопасным рандомом), вычисляет HMAC (на базе SHA2 или SHA3) от хода со сгенерированным ключом, показывает пользователя HMAC. После этого пользователь получает "меню" 1 - Камень, 2 - Ножницы, ...., 0 - Exit, ? - Help. Пользователь делает свой выбор (при некорректном вводе опять отображается "меню"). Скрипт показывает кто победил, ход компьютера и исходный ключ.
Таким образом, пользователь может проверить, что компьютер играет честно (не поменял свой ход после хода пользователя).

При выборе опции "?" (Help) в терминале нужно отобразить таблицу, определяющую какой ход выигрывает.

Генерация таблицы должна быть вынесена в отдельный класс и обязательно использовать стороннюю библиотеку для генерации ASCII-таблиц, определение "правил" кто победил должно быть в отдельном классе, функции генерации ключа и HMAC должны быть в отдельном классе (всего 4 класса). По максимуму следует использовать базовые библиотеки классов и сторонние библиотеки, а не изобретать велосипед.

ЧИСЛО ХОДОВ МОЖЕТ БЫТЬ ЛЮБЫМ (нечетным > 1, зависит от переданных параметров), не зашито в коде.
