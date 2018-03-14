/* Explaning
    As the concept of reducer is always be an pure function, We need to
    return an new object every time we make a change on that object
*/

/**
 * @class This class handle the pure functions to an array of our Entity
 * @type {TEntity} Extends the @see Nicollas.Dto.baseEntityDto with the Key
 * @type {TKey} The key used on TEntity
 */
export class Filter<TEntity extends Nicollas.Dto.baseEntityDto<TKey>, TKey> {
    key: any;
    values: Array<TEntity>;

    constructor(values: Array<TEntity>, key: any = 'unique') {
        this.key = key;
        this.values = values;
    }

    /**
     * Check if exist some Entity with the key
     * @param id The id to look
     */
    exists(id: TKey) { return this.values.some(row => row.id === id); }

    /**
     * Get an entity by value
     * @param id The id to find
     */
    find(id: TKey) { return Object.assign({}, this.values.find(row => row.id === id)) ; }

    /**
     * Get an entity by an action
     * @param filter The action
     */
    where(filter: (row: TEntity) => boolean ) { return Object.assign({}, this.values.find(filter)) ; }

    /**
     * return a new filter with the new entity inserted
     * @param entity The entity to be inserted
     */
    insert(entity: TEntity): Filter<TEntity, TKey> {
        return new Filter<TEntity, TKey>([...this.values, entity], this.key);
    }

    /**
     * return a new filter with the entity updated
     * @param entity The entity to be updated
     */
    update(entity: TEntity): Filter<TEntity, TKey> {
        const index = this.values.findIndex(r => r.id === entity.id);
        if (index < 0) {
            throw new Error('Entity not found');
        }
        return new Filter<TEntity, TKey>(
        [...this.values.slice(0, index), entity, ...this.values.slice(index + 1)], this.key);
    }

    /**
     * return a new filter without the entity
     * @param entity The entity to be removed
     */
    remove(entity: TEntity): Filter<TEntity, TKey> {
        return new Filter<TEntity, TKey>([...this.values.filter(row => row.id !== entity.id)], this.key);
    }
}


/**
 * Update the entity on every filter that is found and return an new array
 * @param array the array of filters to be updated
 * @param entity the entity to be updated
 */
export function PureReplaceEntity<TEntity extends Nicollas.Dto.baseEntityDto<TKey>, TKey>
    (array: Filter<TEntity, TKey>[], entity: TEntity): Filter<TEntity, TKey>[] {
    let result = array;

    array.forEach((element, index) => {
        if (element.exists(entity.id)) {
            result = PureReplace(result, element.update(entity));
        }
    });

    return result;
}

/**
 * insert or update the filter and return an new array
 * @param array the array of filters to insert or update
 * @param filter the filter to insert or update
 */
export function PureInsertOrUpdate<TEntity extends Nicollas.Dto.baseEntityDto<TKey>, TKey>
    (array: Filter<TEntity, TKey>[], filter: Filter<TEntity, TKey>): Filter<TEntity, TKey>[] {
    return array.some(row => row.key === filter.key) ? PureReplace(array, filter) : PureInsert(array, filter);
}

/**
 * update the filter and return an new array
 * @param array the array of filters to update
 * @param filter the filter to update
 * @throws Error when the filter is not on the array
 */
export function PureReplace<TEntity extends Nicollas.Dto.baseEntityDto<TKey>, TKey>
    (array: Filter<TEntity, TKey>[], filter: Filter<TEntity, TKey>): Filter<TEntity, TKey>[] {

    const index = array.findIndex(r => r.key === filter.key);
    if (index < 0) {
        throw new Error('Key not found');
    }
    return [...array.slice(0, index), filter, ...array.slice(index + 1)];
}

/**
 * Remove the filter from array and return an new array
 * @param array the array of filters to remove
 * @param filter to remove
 */
export function PureRemove<TEntity extends Nicollas.Dto.baseEntityDto<TKey>, TKey>
    (array: Filter<TEntity, TKey>[], filter: Filter<TEntity, TKey>): Filter<TEntity, TKey>[] {

    return [...array.filter(row => row.key === filter.key)];
}

/**
 * insert the filter and return an new array
 * @param array the array of filters to insert a new one
 * @param filter the filter to insert
 */
export function PureInsert<TEntity extends Nicollas.Dto.baseEntityDto<TKey>, TKey>
    (array: Filter<TEntity, TKey>[], filter: Filter<TEntity, TKey>): Filter<TEntity, TKey>[] {
    return [...array, filter];
}
