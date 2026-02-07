using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MvcCv.Repositories
{
    //Bu sınıf, CRUD (Create, Read, Update, Delete)
    //işlemlerini tüm veritabanı tabloları için genel bir
    //şekilde sağlayarak kod tekrarını azaltır ve uygulamanın bakımını kolaylaştırır.
    public class GenericReporsitory<T> where T:class, new()
    {
        DbCvEntities db = new DbCvEntities();

        public List<T> List()
        {
            return db.Set<T>().ToList();  // bana T den gelen değeri liste olarak gönder, buradaki T değeri tüm tabloları kapsar, bu br iskelet yapıdır
                                          //Bu metod, veritabanındaki T tipindeki tüm kayıtları listeler. db.Set<T>() ifadesi, T tipine ait DbSet'i
                                          //(veritabanı tablosunu) döndürür ve .ToList() metodu ile bu kayıtların bir listesini alırız.
        }

        public void TAdd(T p) //ekleme
        { 
            db.Set<T>().Add(p);
            db.SaveChanges();
            //TAdd metodu, T tipinde yeni bir nesneyi DbSet'e ekler ve db.SaveChanges() ile değişiklikleri veritabanına kaydeder.
        }

        public void TDelete(T p)  //silme
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
            //TDelete metodu, T tipindeki bir nesneyi DbSet'ten kaldırır ve db.SaveChanges() ile bu değişikliği veritabanına kaydeder.
        }

        public T TGet(int id)
        {
            return db.Set<T>().Find(id);
            //TGet metodu, belirtilen id değerine sahip olan T tipindeki nesneyi bulur. Bu işlem için Entity Framework'ün Find metodu kullanılır.
        }

        public void TUpdate(T p)  //güncelleme
        {        
            db.SaveChanges();
        }

        public T Find(Expression<Func<T, bool>> where) // Bu argüman, T tipindeki nesneler üzerinde uygulanacak bir koşul (predicate) fonksiyonudur
        {
            return db.Set<T>().FirstOrDefault(where);
            //Metodun içinde, db.Set<T>() ifadesi T tipindeki tüm nesneleri içeren bir DbSet döndürür. FirstOrDefault metodu ise,
            //sağlanan where koşulunu karşılayan ilk nesneyi döner. Eğer koşulu karşılayan bir nesne bulunamazsa, null değer döner.
        }
    }
}