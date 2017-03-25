using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> {

	public List<T> pool	 { get; set;}
	public int count	 { get; set;}

	public Pool(){
		count = 2; //default value

		pool = new List<T>();
	}

	public Pool(int count){
		this.count = count;

		pool = new List<T>();
	}
}
