

// x 在区间[t1,t2] 中, 求区间[s1,s2] 中同比例的点的值;
float remap( float t1, float t2, float s1, float s2, float x )
{
    return ((x - t1) / (t2 - t1) * (s2 - s1) + s1);
}


