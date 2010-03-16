﻿#if ENABLE_PROPERTY
/*
 * GatetimePropertyConverter.cs
 * Copyright (C) 2009-2010 kbinani
 *
 * This file is part of org.kbinani.cadencii.
 *
 * org.kbinani.cadencii is free software; you can redistribute it and/or
 * modify it under the terms of the GPLv3 License.
 *
 * org.kbinani.cadencii is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.
 */
using System;
using System.ComponentModel;
using System.Globalization;

namespace org.kbinani.cadencii {
    using boolean = Boolean;

    public class GatetimePropertyConverter : ExpandableObjectConverter {
        //コンバータがオブジェクトを指定した型に変換できるか
        //（変換できる時はTrueを返す）
        //ここでは、CustomClass型のオブジェクトには変換可能とする
        public override boolean CanConvertTo( ITypeDescriptorContext context, Type destinationType ) {
            if ( destinationType == typeof( GatetimeProperty ) ) {
                return true;
            }
            return base.CanConvertTo( context, destinationType );
        }

        //指定した値オブジェクトを、指定した型に変換する
        //CustomClass型のオブジェクトをString型に変換する方法を提供する
        public override object ConvertTo( ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType ) {
            if ( destinationType == typeof( String ) && value is GatetimeProperty ) {
                GatetimeProperty cp = (GatetimeProperty)value;
                return cp.Measure.getIntValue() + " : " + cp.Beat.getIntValue() + " : " + cp.Gate.getIntValue();
            }
            return base.ConvertTo( context, culture, value, destinationType );
        }

        //コンバータが特定の型のオブジェクトをコンバータの型に変換できるか
        //（変換できる時はTrueを返す）
        //ここでは、String型のオブジェクトなら変換可能とする
        public override boolean CanConvertFrom( ITypeDescriptorContext context, Type sourceType ) {
            if ( sourceType == typeof( String ) ) {
                return true;
            }
            return base.CanConvertFrom( context, sourceType );
        }

        //指定した値をコンバータの型に変換する
        //String型のオブジェクトをCustomClass型に変換する方法を提供する
        public override object ConvertFrom( ITypeDescriptorContext context, CultureInfo culture, object value ) {
            if ( value is String ) {
                String[] ss = ((String)value).Split( new char[] { ':' }, 3 );
                CalculatableString cs = new CalculatableString();
                cs.setStr( ss[0] );
                int measure = cs.getIntValue();
                cs.setStr( ss[1] );
                int beat = cs.getIntValue();
                cs.setStr( ss[2] );
                int gate = cs.getIntValue();
                return new GatetimeProperty( measure, beat, gate );
            }
            return base.ConvertFrom( context, culture, value );
        }
    }

}
#endif