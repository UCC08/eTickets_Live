﻿namespace eTickets_Live.Data.Base
{
    // tüm program genelinde hizmet verecek bir interface , ortak kullanılacak metotların imzalarını(tanımlarını) tutacak bir yapı. Aynı zamamanda her sınıf için görev yapacağından üzerine gelen parametrelerin  tipleri Generic yapıda olacak.
    public interface IEntityBaseRepository<T> where T : class,IEntityBase,new()
    {
        IEnumerable<T> GetAll(); // tüm bölümlerde db den kayıtları getirmek için

        T GetById(int id); // Id bilgine göre tek kayıt getirmek için

        void Add(T entity); // servis üzerinden kayıt ekleme yapacak metot

        void Update(int id,T entity); // servis üzerinden güncelleme yapacak metot

        void Delete(int id); // servis üzerinden silme işlemi yapacak metot
    }
}
