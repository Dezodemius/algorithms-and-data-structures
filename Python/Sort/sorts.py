from Algorithm.Search import Search


def bubble(a, in_reverse=False):
    """ Bubble sort.

        :param a: Input array.
        :param in_reverse: In reverse flag.
    """
    if in_reverse:
        for i in range(1, len(a), 1):
            is_sorted = False
            for j in range(0, len(a) - i, 1):
                if a[j] < a[j + 1]:
                    a[j], a[j + 1] = a[j + 1], a[j]
                    is_sorted = False
            if is_sorted:
                return
    else:
        for i in range(1, len(a), 1):
            is_sorted = False
            for j in range(0, len(a) - i, 1):
                if a[j] > a[j + 1]:
                    a[j], a[j + 1] = a[j + 1], a[j]
                    is_sorted = False
            if is_sorted:
                return


def insertion(a, in_reverse=False):
    """Insertion sort.

        :param a: Input array.
        :param in_reverse: In reverse flag.
    """
    if in_reverse:
        return "Not supported now."
    else:
        for i in range(len(a)):
            j = 0
            while j < i and a[i] >= a[j]:
                j += 1
            while j < i:
                a[i], a[j] = a[j], a[i]
                j += 1


def binary_insertion(a, in_reverse=False):
    """Insertion sort.

        :param a: Input array.
        :param in_reverse: In reverse flag.
    """
    if in_reverse:
        return "Not supported now."
    else:
        n = len(a)
        for i in range(1, n):
            key = a[i]
            key_position = Search.binary_recursion(a, key, 0, i) + 1
            for k in range(i, key_position, -1):
                a[k] = a[k - 1]
            a[key_position] = key


def shell(a):
    """Shell's sort.

        :param a: Input array.
    """
    n = len(a)
    gap = n // 2

    while gap > 0:
        for i in range(gap, n):
            tmp = a[i]
            j = i
            while j >= gap and a[j - gap] > tmp:
                a[j] = a[j - gap]
                j -= gap
            a[j] = tmp
        gap //= 2


if __name__ == "__main__":
    print("Not for execution.")
