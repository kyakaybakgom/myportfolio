using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data<T>
{
    private T data;

    public T Value
    {
        get
        {
            return this.data;
        }

        set
        {
            this.data = value;
            this.onChange?.Invoke(this.data);
        }
    }

    public Action<T> onChange;
}
