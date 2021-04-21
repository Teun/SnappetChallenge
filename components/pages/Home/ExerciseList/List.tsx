import React, { useEffect, useState } from 'react';
import { AutoSizer, List as VirtualizedList } from 'react-virtualized';
import { useWindowSize } from 'react-use';

import { Exercise } from '@lib/models/Exercise';
import ListItem from './ListItem';

interface ListProps {
  exercises: Exercise[];
}

const List: React.FC<ListProps> = ({ exercises }) => {
  const { width } = useWindowSize();
  const [rowHeight, setRowHeight] = useState(0);

  useEffect(() => {
    setRowHeight(getRowHeight());
  }, [width]);

  return (
    <div style={{ flex: 1 }}>
      <AutoSizer>
        {({ width, height }) => (
          <VirtualizedList
            width={width}
            height={height}
            rowCount={exercises.length}
            rowHeight={rowHeight}
            rowRenderer={({ index, key, style }) => (
              <div key={key} style={style}>
                <ListItem exercise={exercises[index]} />
              </div>
            )}
          />
        )}
      </AutoSizer>
    </div>
  );
};

export default React.memo(List);

const getRowHeight = () => {
  const screenWidth = window.innerWidth;

  if (screenWidth < 600) {
    return 264;
  }

  if (screenWidth < 960) {
    return 232;
  }

  return 192;
};
