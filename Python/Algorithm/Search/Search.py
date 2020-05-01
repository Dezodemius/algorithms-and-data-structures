def binary(a, key) -> int:
    """Binary search.

        :param a - Input array.
        :param key - Required element.
        :return Position of key.
    """
    left = 0
    mid = len(a) // 2
    right = len(a) - 1

    if left >= right:
        return 0

    while a[mid] != key and left <= right:
        if key > a[mid]:
            left = mid + 1
        else:
            right = mid - 1
        mid = (left + right) // 2

    if left > right:
        return -1
    else:
        return mid


def binary_recursion(a, key, left, right) -> int:
    """Binary search with recursion.

        :param a: Input array.
        :param key: Required element.
        :param left: Left bound.
        :param right: Right bound.
        :return: Position of key.
    """
    if right - left <= 1:
        if key < a[left]:
            return left - 1
        else:
            return left
    mid = (left + right) // 2
    if a[mid] < key:
        return binary_recursion(a, key, mid, right)
    elif a[mid] > key:
        return binary_recursion(a, key, left, mid)
    else:
        return mid


def exponential(a, key) -> int:
    """Exponential search

        :param a: Input array.
        :param key: Required element.
        :return: Position of key.
    """
    if a[0] == key:
        return 0
    n = len(a)
    i = 1
    while i < n and a[i] < key:
        i *= 2
    return binary_recursion(a, key, i // 2, min(i + 1, n))

