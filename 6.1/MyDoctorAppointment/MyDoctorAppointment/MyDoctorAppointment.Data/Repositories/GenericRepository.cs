using MyDoctorAppointment.Data.Interfaces;
using MyDoctorAppointment.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyDoctorAppointment.Data.Repositories
{
    public abstract class GenericRepository<TSource> : IGenericRepository<TSource> where TSource : Auditable
    {
        public string AppSettings { get; private set; }
        public ISerializationService SerializationService { get; private set; }

        public abstract string Path { get; set; }
        public abstract int LastId { get; set; }

        public GenericRepository(string appSettings, ISerializationService serializationService)
        {
            AppSettings = appSettings ?? throw new ArgumentNullException(nameof(appSettings));
            SerializationService = serializationService ?? throw new ArgumentNullException(nameof(serializationService));
        }

        public TSource Create(TSource source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            source.Id = ++LastId;
            source.CreatedAt = DateTime.Now;

            var items = GetAll().Append(source).ToList();

            Save(items);
            SaveLastId();

            return source;
        }

        public bool Delete(int id)
        {
            if (GetById(id) is null)
            {
                return false;
            }

            var items = GetAll().Where(x => x.Id != id).ToList();
            Save(items);
            return true;
        }

        public IEnumerable<TSource> GetAll()
        {
            if (string.IsNullOrWhiteSpace(Path)) throw new ArgumentNullException(nameof(Path));
            if (SerializationService == null) throw new ArgumentNullException(nameof(SerializationService));

            // Для XML десериализуем в List<TSource>
            if (Path.EndsWith(".xml"))
            {
                var list = SerializationService.Deserialize<List<TSource>>(Path);
                return list ?? Enumerable.Empty<TSource>();
            }

            // Для JSON возвращаем как IEnumerable<TSource>
            return SerializationService.Deserialize<IEnumerable<TSource>>(Path) ?? Enumerable.Empty<TSource>();
        }

        public TSource? GetById(int id)
        {
            return GetAll().FirstOrDefault(x => x.Id == id);
        }

        public TSource Update(int id, TSource source)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));

            source.UpdatedAt = DateTime.Now;
            source.Id = id;

            var items = GetAll().Select(x => x.Id == id ? source : x).ToList();
            Save(items);

            return source;
        }

        public abstract void ShowInfo(TSource source);
        protected abstract void SaveLastId();

        protected Repository ReadFromAppSettings()
        {
            return SerializationService.Deserialize<Repository>(AppSettings);
        }

        private void Save(IEnumerable<TSource> items)
        {
            if (Path.EndsWith(".xml"))
            {
                // Для XML сериализуем как List<TSource>
                SerializationService.Serialize(Path, items.ToList());
            }
            else
            {
                // Для JSON сериализуем как IEnumerable<TSource>
                SerializationService.Serialize(Path, items);
            }
        }
    }
}
