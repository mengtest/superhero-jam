using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pool<T> {

	public List<T> pool	 { get; set;}
	public int count	 { get; set;}
	public int deployed	 { get; set;}

	public Pool(){
		count = 2; //default value

		pool = new List<T>();
		deployed = 0;
	}

	public Pool(int count){
		this.count = count;

		pool = new List<T>();
		deployed = 0;
	}
}
